namespace Examples.Lib.mesh.generate;

[Guid("a469ca9f-a7f9-46b8-b34c-0a1c109e1222")]
 internal sealed class ExtrudeCurvesExample : Instance<ExtrudeCurvesExample>
{
    [Output(Guid = "7661ebdf-0d10-437a-8b3e-71fac37cbd1a")]
    public readonly Slot<Texture2D> ColorBuffer = new Slot<Texture2D>();

    [Input(Guid = "7c55d6c6-d712-4464-8dd8-2b7fac96e270")]
    public readonly InputSlot<bool> FixHoles = new InputSlot<bool>();


}