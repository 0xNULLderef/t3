using T3.Core.DataTypes;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_a53a0643_8daa_49c2_9c8c_34cfe5ad8030
{
    public class _VisualizePointFields : Instance<_VisualizePointFields>
    {
        [Output(Guid = "b4869782-4b4c-4250-8bdc-54a4c74ec1c0")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "b9a71525-a923-47fd-b3ef-8bce4837042b")]
        public readonly MultiInputSlot<BufferWithViews> FieldPointsBuffer = new MultiInputSlot<BufferWithViews>();

        [Input(Guid = "59cb2727-8562-4a44-b57e-dcb52df568fd")]
        public readonly InputSlot<int> Count = new InputSlot<int>();

        [Input(Guid = "587a630d-8163-4304-911f-d8f8ea781106")]
        public readonly InputSlot<float> Range = new InputSlot<float>();

        [Input(Guid = "83727898-5fc0-40df-a199-830cda49d9b6")]
        public readonly InputSlot<float> Offset = new InputSlot<float>();

    }
}

