namespace Types;

// ReSharper disable once UnusedType.Global
public sealed class ShareDefinition : IShareResources
{
    // ReSharper disable once EmptyConstructor
    public ShareDefinition(){}
    #pragma warning disable CA1822
    public bool ShouldShareResources => true;
    #pragma warning restore CA1822
}