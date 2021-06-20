using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text display;
    private Counter _counter;

    private void Start()
    {
        _counter = new Counter();
    }

    private void Update()
    {
        float time = _counter.Count * WorldManager.Instance.TimeScale;
        display.text = $"{time:0.000}";
        _counter.IncrementBy(Time.deltaTime);
    }
}
