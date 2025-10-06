using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public Vector3 direction;

    private SpriteRenderer rend;
    private VisualProperties.ProjectileVisuals visuals;
    private Color color;
    private Sprite sprite;
    private RuntimeAnimatorController animator;

    public void Init()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
        visuals = VisualProperties.inst.projectileVisuals;

        if (visuals.animController != null)
        {
            animator = visuals.animController;
            var anim = gameObject.AddComponent<Animator>();
            anim.runtimeAnimatorController = animator;
        }
        else if (visuals.sprite != null)
        {
            sprite = visuals.sprite;
            rend.sprite = sprite;
        }
        else
        {
            color = visuals.color;
            rend.color = color;
        }

        // --- NEW: rotate sprite to face travel direction ---
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Adjust this offset depending on your art:
            // - If sprite points RIGHT by default → use angle
            // - If sprite points UP by default → use angle - 90
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void Update()
    {
        if (rend != null && rend.isVisible)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
