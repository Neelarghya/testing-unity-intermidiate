namespace TestUtils
{
    public class MockStepCounter : StepCounter
    {
        public bool wasIncrementByCalled;
        
        public override void IncrementStep()
        {
            wasIncrementByCalled = true;
        }
    }
}