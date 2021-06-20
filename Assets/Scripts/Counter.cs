public class Counter
{
    public int Count { get; private set; }

    public void Reset()
    {
        Count = 0;
    }
    
    public void Increment()
    {
        Count++;
    }

    public void IncrementBy(int amount)
    {
        Count += amount;
    }
}
