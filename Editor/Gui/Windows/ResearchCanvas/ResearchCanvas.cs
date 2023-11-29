﻿using System.Collections.Generic;
using ImGuiNET;

namespace T3.Editor.Gui.Windows.ResearchCanvas;

public class ResearchWindow : Window
{
    public ResearchWindow()
    {
        Config.Title = "Research";
        MenuTitle = "Research";
        WindowFlags = ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse;
    }

    protected override void DrawContent()
    {
        _verticalStackingCanvas.Draw();
    }
    
    public override List<Window> GetInstances()
    {
        return new List<Window>();
    }

    private readonly VerticalStackingCanvas _verticalStackingCanvas = new();
}