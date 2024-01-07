using System.Runtime.InteropServices;
using lib.Utils;
using T3.Core.Animation;
using T3.Core.DataTypes;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Core.Utils;

namespace lib.io.time.vj
{
	[Guid("f5158500-39e4-481e-aa4f-f7dbe8cbe0fa")]
    public class SetBpm : Instance<SetBpm>
    {
        [Output(Guid = "05C17586-CF93-4244-9979-47E310ABAF31")]
        public readonly Slot<Command> Commands = new();
        
        public SetBpm()
        {
            Commands.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            
            var bpm = BpmRate.GetValue(context);

            var wasTriggered = MathUtils.WasTriggered(TriggerUpdate.GetValue(context), ref _bpmProvider.TriggerUpdate);
            
            var clampedRate = bpm.Clamp(54, 240);
            if (wasTriggered && bpm > 1)
            {
                if (Playback.Current == null)
                {
                    Log.Warning("Can't set BPM-Rate without active Playback", this);
                    return;
                }
                Log.Debug($"Setting BPM rate to {clampedRate}", this);
                //Playback.Current.Bpm = clampedRate;
                _bpmProvider.SetBpmTriggered = true;
                _bpmProvider.NewBpmRate = clampedRate;
            }
            
            SubGraph.GetValue(context);
        }

        
        
        [Input(Guid = "9CC32DA8-F939-4AD3-B381-6DF8338A371B")]
        public readonly InputSlot<Command> SubGraph = new();
                
        [Input(Guid = "721C34B5-BB06-49E0-A71E-2AEBBF2557E0")]
        public readonly InputSlot<float> BpmRate = new();
        
        [Input(Guid = "FBF10760-B559-4E9C-B8DC-CE61D3F21C82")]
        public readonly InputSlot<bool> TriggerUpdate = new();
        
        private readonly BpmProvider _bpmProvider = BpmProvider.Instance;
    }
}