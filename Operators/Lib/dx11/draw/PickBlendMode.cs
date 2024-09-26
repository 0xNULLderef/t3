using System.Runtime.InteropServices;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Core.Utils;

namespace lib.dx11.draw
{
	[Guid("fd9bffd3-5c57-462f-8761-85f94c5a629b")]
    public class PickBlendMode : Instance<PickBlendMode>
    {

        [Output(Guid = "a42dd1c5-886c-4fa9-bf69-8b6321a48930")]
        public readonly Slot<SharpDX.Direct3D11.BlendState> Result2 = new();

        [Input(Guid = "30b58444-0485-4116-8b15-7e62fee69eaa", MappedType = typeof(SharedEnums.BlendModes))]
        public readonly InputSlot<int> BlendMode = new();
    }
}

