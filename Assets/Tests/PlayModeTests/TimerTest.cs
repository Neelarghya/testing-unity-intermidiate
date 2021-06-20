using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TimerTest
{
    private Timer _timer;
    private Text _display;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        GameObject gameObject = new GameObject();
        _timer = gameObject.AddComponent<Timer>();
        _display = gameObject.AddComponent<Text>();
        _timer.display = _display;
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