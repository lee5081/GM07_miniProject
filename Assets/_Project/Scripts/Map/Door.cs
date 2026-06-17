using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isOpen;

    private void Reset()
    {
        doorCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        ApplyState();
    }

    public void Open()
    {
        isOpen = true;
        ApplyState();
    }

    public void Close()
    {
        isOpen = false;
        ApplyState();
    }

    private void ApplyState()
    {
        if (doorCollider != null)
        {
            doorCollider.enabled = !isOpen;
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = !isOpen;
        }
    }
}
