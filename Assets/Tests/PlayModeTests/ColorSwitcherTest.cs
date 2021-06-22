using NSubstitute;
using NUnit.Framework;
using TestUtils;
using UnityEngine;

public class ColorSwitcherTest
{
    private ColorSwitcher _colorSwitcher;
    private Renderer _renderer;
    private ColorGenerator _colorGenerator;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _colorSwitcher = new ColorSwitcher();
        _renderer = GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<Renderer>();
        _colorGenerator = Substitute.For<ColorGenerator>();
        ReflectionUtils.SetFieldValue(_colorSwitcher, "renderer", _renderer);
        ReflectionUtils.SetFieldValue(_colorSwitcher, "colorGenerator", _colorGenerator);
    }

    [TearDown]
    public void TearDown()
    {
        _colorGenerator.ClearReceivedCalls();
    }

    [Test]
    public void ShouldSwitchColorToWhatTheGeneratorProvides()
    {
        Color expectedColor = Color.yellow;
        _colorGenerator.GetRandomColor().Returns(expectedColor);
        
        _colorSwitcher.SwitchColor();
        
        _colorGenerator.Received(1).GetRandomColor();
        Assert.AreEqual(expectedColor, _renderer.material.color);
    }

    [Test]
    public void ShouldPassCorrectDefaultHueWhenResetting()
    {
        float defaultHue = 0.75f;
        float passedHue = 0f;
        _colorGenerator.GetColorWithHue(Arg.Do<float>(hue => passedHue = hue));
        
        ReflectionUtils.SetFieldValue(_colorSwitcher, "defaultHue", defaultHue);
        ReflectionUtils.SetFieldValue(_colorSwitcher, "renderer", _renderer);
        
        _colorSwitcher.ResetColor();
        
        _colorGenerator.Received(1).GetColorWithHue(defaultHue);
        Assert.AreEqual(defaultHue, passedHue);
    }
}