namespace examples.howto
{
	[Guid("9b1a1ff1-2935-4d9a-880f-897a7f8885ad")]
    public class HowToAnimate : Instance<HowToAnimate>
    {
        [Output(Guid = "23bc598c-e87d-4993-9e09-b4676e302e61")]
        public readonly Slot<Texture2D> ColorBuffer = new();


    }
}

