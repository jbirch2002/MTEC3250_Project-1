using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 1f; // how long before it disappears

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
