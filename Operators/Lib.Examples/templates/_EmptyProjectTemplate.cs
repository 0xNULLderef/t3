using System.Runtime.InteropServices;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.Examples.templates
{
	[Guid("fe8aeb9b-61ac-4a0e-97ee-4833233ac9d1")]
    public class _EmptyProjectTemplate : Instance<_EmptyProjectTemplate>
    {
        [Output(Guid = "630f459e-6825-443d-b1ca-a682aafa65a9")]
        public readonly Slot<Texture2D> ImgOutput = new();


    }
}

