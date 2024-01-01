using System.Runtime.InteropServices;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.User.pixtur.vj
{
	[Guid("9e967eb6-b336-4ffc-9be0-88205f8ea0f0")]
    public class VjFaceSplits : Instance<VjFaceSplits>
    {
        [Output(Guid = "0c7abf51-2698-46ee-98c9-704a560e0965")]
        public readonly Slot<Command> Output = new();


    }
}

