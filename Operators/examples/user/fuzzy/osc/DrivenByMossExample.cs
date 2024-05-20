using System.Runtime.InteropServices;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace examples.user.fuzzy.osc
{
    [Guid("245de58f-d3d0-4c57-ba27-1b884b7f6b31")]
    public class DrivenByMossExample : Instance<DrivenByMossExample>
    {

        [Output(Guid = "c16c7b14-2cb1-4160-b48f-d6a4e4619a53")]
        public readonly Slot<T3.Core.DataTypes.Command> OutputCommand = new Slot<T3.Core.DataTypes.Command>();

    }
}

