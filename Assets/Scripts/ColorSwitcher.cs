using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    [SerializeField] private ColorGenerator colorGenerator;
    [SerializeField] private new Renderer renderer;
    [SerializeField, Range(0f, 1f)] private float defaultHue = 0.5f;

    public void SwitchColor()
    {
        renderer.material.color = colorGenerator.GetRandomColor();
    }

    public void ResetColor()
    {
        renderer.material.color = colorGenerator.GetColorWithHue(defaultHue);
    }
}