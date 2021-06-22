using UnityEngine;

public class StepCounter : MonoBehaviour
{
    private Counter _counter;

    private void Start()
    {
        _counter = new Counter();
    }

    public virtual void IncrementStep()
    {
        _counter.IncrementBy(1);
        Debug.Log($"Step: {_counter.Count}");
    }
}