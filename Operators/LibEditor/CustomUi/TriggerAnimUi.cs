﻿using System.Numerics;
using ImGuiNET;
using Lib.numbers.anim.animators;
using T3.Core.Operator;
using T3.Core.Utils;
using T3.Editor.Gui.ChildUi.WidgetUi;
using T3.Editor.Gui.Styling;
using T3.Editor.Gui.UiHelpers;
using T3.Editor.UiModel;

namespace libEditor.CustomUi;

public static class TriggerAnimUi
{
    public static SymbolUi.Child.CustomUiResult DrawChildUi(Instance instance, ImDrawListPtr drawList, ImRect screenRect, Vector2 canvasScale)
    {
        if (!(instance is TriggerAnim anim)
            || !ImGui.IsRectVisible(screenRect.Min, screenRect.Max))
            return SymbolUi.Child.CustomUiResult.None;

        ImGui.PushID(instance.SymbolChildId.GetHashCode());
        // if (RateEditLabel.Draw(ref triggerAnimation.Rate.TypedInputValue.Value,
        //                        screenRect, drawList, nameof(triggerAnimation) + " " + (LFO.Shapes)triggerAnimation.Shape.TypedInputValue.Value))
        // {
        //     triggerAnimation.Rate.Input.IsDefault = false;
        //     triggerAnimation.Rate.DirtyFlag.Invalidate();
        // }

        var isEditActive = false;

        var h = screenRect.GetHeight();
        var graphRect = screenRect;

        if (h < 10)
        {
            return SymbolUi.Child.CustomUiResult.None;
        }
            

        graphRect.Expand(-3);
            
        //graphRect.Min.X = graphRect.Max.X - graphRect.GetWidth();
        var graphWidth = graphRect.GetWidth();
        drawList.PushClipRect(graphRect.Min, graphRect.Max, true);

        var highlightEditable = ImGui.GetIO().KeyCtrl;

        if (h > 14)
        {
            isEditActive|=ValueLabel.Draw(drawList, graphRect, new Vector2(1, 0), anim.Amplitude);
            isEditActive|=ValueLabel.Draw(drawList, graphRect, new Vector2(1, 1), anim.Base);
        }
            
        // Graph dragging to edit Bias and Ratio
        var isGraphActive = false;
            
        ImGui.SetCursorScreenPos(graphRect.Min);
        if (ImGui.GetIO().KeyCtrl)
        {
            ImGui.InvisibleButton("dragMicroGraph", graphRect.GetSize());
            isGraphActive = ImGui.IsItemActive();
        }

        var duration = anim.Duration.GetCurrentValue();
            
        if (isGraphActive)
        {
            isEditActive = true;
            var dragDelta = ImGui.GetMouseDragDelta(ImGuiMouseButton.Left, 1);
            
            if (ImGui.IsItemActivated())
            {
                //_dragStartPosition = ImGui.GetMousePos();
                _dragStartBias = anim.Bias.GetCurrentValue();// anim.Bias.TypedInputValue.Value;
                _dragStartDuration = anim.Duration.GetCurrentValue();
            }
            
            if (MathF.Abs(dragDelta.X) > 0.5f)
            {
                anim.Duration.SetTypedInputValue((_dragStartDuration + dragDelta.X / 100f).Clamp(0.001f, 4f));
            }
            
            if (Math.Abs(dragDelta.Y) > 0.5f)
            {
                anim.Bias.SetTypedInputValue((_dragStartBias - dragDelta.Y / 100f).Clamp(0.01f, 0.99f));
            }
        }

        var delay = anim.Delay.GetCurrentValue();//.Value;
            
        // Draw Graph
        {
            const float previousCycleFragment = 0.02f;
            const float relativeX = previousCycleFragment / (1 + previousCycleFragment);

            // Horizontal line
            var lh1 = graphRect.Min + Vector2.UnitY * h / 2;
            var lh2 = new Vector2(graphRect.Max.X, lh1.Y + 1);
            drawList.AddRectFilled(lh1, lh2, UiColors.WidgetAxis);

            // Vertical start line 
            var lv1 = graphRect.Min + Vector2.UnitX * (int)(graphWidth * relativeX);
            var lv2 = new Vector2(lv1.X + 1, graphRect.Max.Y);
            drawList.AddRectFilled(lv1, lv2, UiColors.WidgetAxis);

            // Fragment line 
            var cycleWidth = graphWidth * (1 - relativeX); 
            var dx = new Vector2(((float)anim.LastFraction * duration + delay) * cycleWidth - 1, 0);
            drawList.AddRectFilled(lv1 + dx, lv2 + dx, UiColors.WidgetActiveLine);

            // Draw graph
            //        lv
            //        |  2-------3    y
            //        | /
            //  0-----1 - - - - - -   lh
            //        |
            //        |
                
                
            // var shapeValue = anim.Shape.HasInputConnections 
            //                      ? anim.Shape.Value 
            //                      :anim.Shape.TypedInputValue.Value;
            var shapeIndex = anim.Shape.GetCurrentValue().Clamp(0, Enum.GetNames<TriggerAnim.Shapes>().Length -1 );

            for (var i = 0; i < GraphListSteps; i++)
            {
                var f = (float)i / GraphListSteps;
                var fragment = f * (1 + previousCycleFragment) - previousCycleFragment;
                GraphLinePoints[i] = new Vector2((f * duration +  delay) * graphWidth,
                                                 (0.5f - anim.CalcNormalizedValueForFraction(fragment, shapeIndex) / 2) * h
                                                ) + graphRect.Min;
            }

            var curveLineColor = highlightEditable ? UiColors.WidgetLineHover : UiColors.WidgetLine;
            drawList.AddPolyline(ref GraphLinePoints[0], GraphListSteps, curveLineColor, ImDrawFlags.None, 1.5f);
        }
        drawList.PopClipRect();
        ImGui.PopID();
        return SymbolUi.Child.CustomUiResult.Rendered 
               | SymbolUi.Child.CustomUiResult.PreventOpenSubGraph 
               | SymbolUi.Child.CustomUiResult.PreventInputLabels
               | SymbolUi.Child.CustomUiResult.PreventTooltip
               | (isEditActive ? SymbolUi.Child.CustomUiResult.IsActive : SymbolUi.Child.CustomUiResult.None);
    }

    private static float _dragStartBias;
    private static float _dragStartDuration;

    private static readonly Vector2[] GraphLinePoints = new Vector2[GraphListSteps];
    private const int GraphListSteps = 80;
}