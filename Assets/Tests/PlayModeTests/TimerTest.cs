using System.Collections;
using NUnit.Framework;
using TestUtils;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TimerTest
{
    private Timer _timer;
    private Text _display;
    private WorldManager _worldManager;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        GameObject gameObject = new GameObject();
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
        ReflectionUtils.SetStaticFieldValue<WorldManager>(ReflectionUtils.ConvertPropertyNameToFieldName("Instance"), null);
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
}