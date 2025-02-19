using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    private Collider2D platformCollider;
    private SpriteRenderer spriteRenderer;

    public GameObject[] toggleButtons; // Array of buttons that can toggle this platform
    public Color solidButtonColor = Color.green;  // Color when platform is solid
    public Color nonSolidButtonColor = Color.red; // Color when platform is not solid

    public bool startSolid = true; // Set initial state in the Inspector
    private bool isSolid;
    private SpriteRenderer[] buttonRenderers;

    private void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get all button renderers
        buttonRenderers = new SpriteRenderer[toggleButtons.Length];
        for (int i = 0; i < toggleButtons.Length; i++)
        {
            if (toggleButtons[i] != null)
                buttonRenderers[i] = toggleButtons[i].GetComponent<SpriteRenderer>();
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

        // Change button colors
        foreach (var buttonRenderer in buttonRenderers)
        {
            if (buttonRenderer != null)
            {
                buttonRenderer.color = isSolid ? solidButtonColor : nonSolidButtonColor;
            }
        }
    }
}