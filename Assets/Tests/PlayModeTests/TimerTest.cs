using System.Collections;
using NUnit.Framework;
using TestUtils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TimerTest
{
    private Timer _timer;
    private Text _display;
    private MockStepCounter _stepCounter;
    private WorldManager _worldManager;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        GameObject gameObject = new GameObject();
        _stepCounter = gameObject.AddComponent<MockStepCounter>();
        _timer = gameObject.AddComponent<Timer>();
        _display = gameObject.AddComponent<Text>();

        new GameObject().AddComponent<WorldManager>();
        _worldManager = WorldManager.Instance;

        ReflectionUtils.SetFieldValue(_timer, "display", _display);
        ReflectionUtils.SetFieldValue(_worldManager, ReflectionUtils.ConvertPropertyNameToFieldName("TimeScale"), 1);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        ReflectionUtils.SetStaticFieldValue<WorldManager>(
            ReflectionUtils.ConvertPropertyNameToFieldName("Instance"), null);
        Object.Destroy(_worldManager.gameObject);
    }

    [UnityTest]
    public IEnumerator TimerDisplayShouldIncreaseOverTime()
    {
        int count = 5;
        float previousValue = float.Parse(_display.text);

        while (count-- > 0)
        {
            yield return null;
            float newValue = float.Parse(_display.text);

            Assert.Greater(newValue, previousValue);

            previousValue = newValue;
        }
    }

    [UnityTest]
    public IEnumerator TimerDisplayShouldIncreaseBy1After1Second()
    {
        float previousValue = float.Parse(_display.text);
        yield return new WaitForSeconds(1);
        float newValue = float.Parse(_display.text);

        Assert.AreEqual(1, newValue - previousValue, 0.01f);
    }

    [UnityTest]
    public IEnumerator ShouldInvokeOnStepEventOnceAfterAStep()
    {
        const float stepSize = 0.5f;
        int callCount = 0;
        UnityEvent onStepEvent = (UnityEvent) ReflectionUtils.GetFieldValue(_timer, "onStepComplete");
        UnityAction action = () => callCount++;
        onStepEvent.AddListener(action);

        ReflectionUtils.SetFieldValue(_timer, "onStepComplete", onStepEvent);
        ReflectionUtils.SetFieldValue(_timer, "stepSize", stepSize);

        yield return new WaitForSeconds(stepSize);

        Assert.AreEqual(1, callCount);

        onStepEvent.RemoveListener(action);
    }

    [UnityTest]
    public IEnumerator ShouldInvokeStepCounterAfterAStep()
    {
        const float stepSize = 0.5f;
        _stepCounter.wasIncrementByCalled = false;

        ReflectionUtils.SetFieldValue(_timer, "stepSize", stepSize);

        yield return new WaitForSeconds(stepSize);

        Assert.IsTrue(_stepCounter.wasIncrementByCalled);
    }
}