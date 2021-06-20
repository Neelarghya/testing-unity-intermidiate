public class Counter
{
    public float Count { get; private set; }

    public void Reset()
    {
        Count = 0;
    }
    
    public void Increment()
    {
        Count++;
    }

    public void IncrementBy(float amount)
    {
        Count += amount;
    }
}
