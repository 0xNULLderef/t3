namespace Lib.image.generate.load;

[Guid("0b3436db-e283-436e-ba85-2f3a1de76a9d")]
internal sealed class LoadImage : Instance<LoadImage>, IDescriptiveFilename, IStatusProvider
{
    [Output(Guid = "E0C4FEDD-5C2F-46C8-B67D-5667435FB037")]
    public readonly Slot<Texture2D> Texture = new();

    public LoadImage()
    {
        _textureResource = ResourceManager.CreateTextureResource(Path);
        _textureResource.AddDependentSlots(Texture);

        
        Texture.UpdateAction = UpdateTexture;
    }

    private void UpdateTexture(EvaluationContext context)
    {
        Texture.Value = _textureResource.GetValue(context);
        Texture.DirtyFlag.Clear();

        if (Texture.Value == null)
        {
            _lastErrorMessage = "Failed to load texture: " + Path.Value;
            Log.Warning(_lastErrorMessage, this);
            return;
        }

        var currentSrv = SrvManager.GetSrvForTexture(Texture.Value);
        
        try
        {
            ResourceManager.Device.ImmediateContext.GenerateMips(currentSrv);
        }
        catch (Exception exception)
        {
            Log.Error($"Failed to generate mipmaps for texture {Path.Value}:" + exception);
        }

        _lastErrorMessage = string.Empty;
    }

    [Input(Guid = "{76CC3811-4AE0-48B2-A119-890DB5A4EEB2}")]
    public readonly InputSlot<string> Path = new();

    public IEnumerable<string> FileFilter => FileFilters;
    private static readonly string[] FileFilters = ["*.png", "*.jpg", "*.jpeg", "*.bmp", "*.tga", "*.dds", "*.gif"];
    public InputSlot<string> SourcePathSlot => Path;

    private readonly Resource<Texture2D> _textureResource;

    IStatusProvider.StatusLevel IStatusProvider.GetStatusLevel() =>
        string.IsNullOrEmpty(_lastErrorMessage) ? IStatusProvider.StatusLevel.Success : IStatusProvider.StatusLevel.Warning;

    string IStatusProvider.GetStatusMessage() => _lastErrorMessage;

    private string _lastErrorMessage = string.Empty;
}