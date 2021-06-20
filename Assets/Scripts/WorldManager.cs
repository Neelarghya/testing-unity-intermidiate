using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public float TimeScale { get; private set; }
    public static WorldManager Instance { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            TimeScale = Random.Range(0.1f, 3f);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}