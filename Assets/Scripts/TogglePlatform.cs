using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    private Collider2D platformCollider;
    private SpriteRenderer spriteRenderer;

    public GameObject toggleButton; // Assign the button GameObject in Inspector
    public Color solidButtonColor = Color.green;  // Color when platform is solid
    public Color nonSolidButtonColor = Color.red; // Color when platform is not solid

    public bool startSolid = true; // Set initial state in the Inspector
    private bool isSolid;
    private SpriteRenderer buttonRenderer;

    private void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (toggleButton != null)
        {
            buttonRenderer = toggleButton.GetComponent<SpriteRenderer>(); // Get button's SpriteRenderer
        }

        isSolid = startSolid; // Set the initial state
        UpdatePlatformState();
    }

    public void Toggle()
    {
        isSolid = !isSolid;
        UpdatePlatformState();
    }

    private void UpdatePlatformState()
    {
        platformCollider.enabled = isSolid;

        // Modify platform transparency
        Color platformColor = spriteRenderer.color;
        platformColor.a = isSolid ? 1f : 0.3f;
        spriteRenderer.color = platformColor;

        // Change button color
        if (buttonRenderer != null)
        {
            buttonRenderer.color = isSolid ? solidButtonColor : nonSolidButtonColor;
        }
    }
}