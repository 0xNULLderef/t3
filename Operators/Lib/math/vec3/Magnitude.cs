using System.Runtime.InteropServices;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace Operators.lib.math.vec3
{
	[Guid("99ce9535-23a3-4570-a98c-8d2262cb8755")]
    public class Magnitude : Instance<Magnitude>
    {
        [Output(Guid = "72788ABC-5ED7-456D-A13E-E56021D7D5F4")]
        public readonly Slot<float> Result = new ();

        public Magnitude()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            Result.Value = Input.GetValue(context).Length();
        }
        
        [Input(Guid = "409e58c9-ad42-40d0-80c2-ed2df2251faa")]
        public readonly InputSlot<System.Numerics.Vector3> Input = new();

    }
}
