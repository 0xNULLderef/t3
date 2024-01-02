using System.Runtime.InteropServices;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.user.pixtur.PixturTestLab
{
	[Guid("a4f8b7e9-a52f-41b6-a63b-d30e5ba77825")]
    public class PixturTestLab : Instance<PixturTestLab>
    {
        [Output(Guid = "486eb33f-111d-4d6e-b81e-9f2ca16cb729")]
        public readonly Slot<Texture2D> Output = new();


    }
}

