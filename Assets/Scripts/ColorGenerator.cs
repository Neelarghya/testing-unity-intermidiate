using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float minSaturation = 0.6f;
    [SerializeField, Range(0f, 1f)] private float minValue = 0.6f;

    public virtual Color GetRandomColor()
    {
        float h = Random.Range(0f, 1f);
        return GetColorWithHue(h);
    }

    public virtual Color GetColorWithHue(float h)
    {
        float s = Random.Range(minSaturation, 1f);
        float v = Random.Range(minValue, 1f);
        return Color.HSVToRGB(h, s, v);
    }
}