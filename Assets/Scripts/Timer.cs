using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text display;
    [SerializeField] private float stepSize = 1f;
    [SerializeField] private UnityEvent onStepComplete;
    private Counter _counter;
    private float _lastCount;

    private void Start()
    {
        _counter = new Counter();
    }

    private void Update()
    {
        float count = _counter.Count;
        float time = count * WorldManager.Instance.TimeScale;
        display.text = $"{time:0.000}";

        if (count - _lastCount >= stepSize)
        {
            _lastCount = count;
            onStepComplete?.Invoke();
        }
        
        _counter.IncrementBy(Time.deltaTime);
    }
}
