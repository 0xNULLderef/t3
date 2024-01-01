using System.Runtime.InteropServices;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.User.pixtur.research
{
	[Guid("0fc6dc9f-713f-4f59-922b-3224454704c5")]
    public class DrawShadowResearch : Instance<DrawShadowResearch>
    {
        [Output(Guid = "fa86ae74-4a84-4ae3-8bcc-2f28414efa29")]
        public readonly Slot<Command> Output = new();


    }
}

