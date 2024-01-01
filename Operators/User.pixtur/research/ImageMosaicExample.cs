using System.Runtime.InteropServices;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.User.pixtur.research
{
	[Guid("56238f0c-bb4c-4883-ab13-80a64887ccd2")]
    public class ImageMosaicExample : Instance<ImageMosaicExample>
    {

        [Output(Guid = "d2ad8648-a738-4fed-a439-fbfbf18f0293")]
        public readonly Slot<SharpDX.Direct3D11.Texture2D> Output = new();

        [Input(Guid = "4d3108c8-9b64-41e8-9550-880d59f411f9")]
        public readonly InputSlot<string> FolderPath = new();


    }
}

