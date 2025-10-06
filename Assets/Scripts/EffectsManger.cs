using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager inst;
    public GameObject goldExplosionPrefab;

    private void Awake() => inst = this;

    public void PlayGoldExplosion(Vector3 pos)
    {
        Instantiate(goldExplosionPrefab, pos, Quaternion.identity);
    }
}
