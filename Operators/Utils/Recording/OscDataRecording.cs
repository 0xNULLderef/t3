﻿using System.Collections.Generic;
using System.Linq;
using Rug.Osc;
using T3.Core.Animation;
using T3.Core.DataTypes.DataSet;
using T3.Core.IO;
using T3.Core.Logging;

namespace Operators.Utils.Recording;

/// <summary>
/// A stub for OSC message recording.
/// </summary>
public class OscDataRecording : OscConnectionManager.IOscConsumer
{
    public double LastEventTime = 0;

    public OscDataRecording(DataSet dataSet)
    {
        _dataSet = dataSet;
        _port = ProjectSettings.Config.DefaultOscPort;

        if (_port is < 0 or > 65535)
        {
            Log.Debug($"Default OSC recording because of invalid port {_port}");
            return;
        }

        OscConnectionManager.RegisterConsumer(this, _port);
    }

    public void ProcessMessage(OscMessage msg)
    {
        if (msg.Count == 0)
            return;

        for (var index = 0; index < msg.Count; index++)
        {
            if (!OscConnectionManager.TryGetValueAndPathForMessagePart(msg[index], out var value))
                continue;

            var pathWithIndex = msg.Count == 1
                                    ? OscConnectionManager.BuildMessageComponentPath(msg)
                                    : OscConnectionManager.BuildMessageComponentPath(msg, index);
            var channel = FindOrCreateChannel(pathWithIndex);

            channel.Events.Add(new DataEvent()
                                   {
                                       Time = Playback.RunTimeInSecs,
                                       TimeCode = Playback.RunTimeInSecs,
                                       Value = value,
                                   });
        }

        LastEventTime = Playback.RunTimeInSecs;
    }

    private DataChannel FindOrCreateChannel(string path)
    {
        var hash = path.GetHashCode();

        if (_channelsByHash.TryGetValue(hash, out var channel))
            return channel;

        var pathSegments = string.IsNullOrEmpty(path)
                               ? new List<string>() { "/" }
                               : path.Split("/").ToList();

        pathSegments[0] = OscNamespacePrefix + ":" + _port;

        var newChannel = new DataChannel(typeof(float))
                             {
                                 Path = pathSegments
                             };
        _channelsByHash[hash] = newChannel;
        _dataSet.Channels.Add(newChannel);
        return newChannel;
    }

    private readonly DataSet _dataSet;
    private readonly int _port;
    private const string OscNamespacePrefix = "OSC";
    private readonly Dictionary<int, DataChannel> _channelsByHash = new();
}