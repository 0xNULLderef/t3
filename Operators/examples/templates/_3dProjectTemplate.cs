using System.Runtime.InteropServices;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.examples.templates
{
	[Guid("38fd2e32-53f6-49ce-9aa7-28f3ac433dd8")]
    public class _3dProjectTemplate : Instance<_3dProjectTemplate>
    {
        [Output(Guid = "455931c4-e7cf-416b-9c80-92bda8127590")]
        public readonly Slot<Texture2D> ImgOutput = new();


    }
}

