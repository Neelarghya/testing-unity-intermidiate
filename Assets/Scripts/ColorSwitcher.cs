using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    [SerializeField] private ColorGenerator colorGenerator;
    [SerializeField] private new Renderer renderer;

    public void SwitchColor()
    {
        renderer.material.color = colorGenerator.GetRandomColor();
    }
}