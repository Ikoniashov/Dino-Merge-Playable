using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(SpriteRenderer))]
public sealed class DinoBreathingSprite : MonoBehaviour
{
    [SerializeField, Range(0f, 0.2f)] private float compression = 0.10f;
    [SerializeField, Min(0.5f)] private float cycleSeconds = 2.8f;

    private SpriteRenderer spriteRenderer;
    private Vector3 basePosition;
    private Vector3 baseScale;
    private float localBottom;
    private float phaseOffset;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        basePosition = transform.localPosition;
        baseScale = transform.localScale;
        localBottom = spriteRenderer.sprite != null ? spriteRenderer.sprite.bounds.min.y : 0f;
        uint hash = unchecked((uint)GetInstanceID() * 2654435761u);
        phaseOffset = (hash & 0xffff) * (Mathf.PI * 2f / 65536f);
    }

    private void Update()
    {
        float phase = Time.time * (Mathf.PI * 2f / cycleSeconds) + phaseOffset;
        float squeeze = compression * (0.5f - 0.5f * Mathf.Cos(phase));
        float scaleY = baseScale.y * (1f - squeeze);

        Vector3 scale = baseScale;
        scale.y = scaleY;
        transform.localScale = scale;

        Vector3 position = basePosition;
        position.y += (baseScale.y - scaleY) * localBottom;
        transform.localPosition = position;
    }

    private void OnDisable()
    {
        transform.localScale = baseScale;
        transform.localPosition = basePosition;
    }
}
