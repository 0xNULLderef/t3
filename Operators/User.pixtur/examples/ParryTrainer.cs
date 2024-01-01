using System.Runtime.InteropServices;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.User.pixtur.examples
{
	[Guid("232efdb7-b8ce-409a-af33-ea1373e256c3")]
    public class ParryTrainer : Instance<ParryTrainer>
    {
        [Output(Guid = "631069b4-3db0-4664-8841-6051c83e3e55")]
        public readonly Slot<Command> Output = new();


    }
}

