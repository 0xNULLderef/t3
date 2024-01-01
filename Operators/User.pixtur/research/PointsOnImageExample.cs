using System.Runtime.InteropServices;
using SharpDX.Direct3D11;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.User.pixtur.research
{
	[Guid("f68fd746-0b4f-4f51-8d7d-f271922c36e8")]
    public class PointsOnImageExample : Instance<PointsOnImageExample>
    {
        [Output(Guid = "f22aa72c-19d2-4fd4-bae2-8eb3b2c0ba82")]
        public readonly Slot<Texture2D> ColorBuffer = new();


    }
}

