using UnityEngine;

public class TogglePlatform : MonoBehaviour
{
    private Collider2D platformCollider;
    private SpriteRenderer spriteRenderer;

    public Sprite solidSprite;    // Assign in Inspector
    public Sprite nonSolidSprite; // Assign in Inspector
    public GameObject toggleButton; // Assign the button GameObject in Inspector

    public bool startSolid = true; // Set initial state in the Inspector
    private bool isSolid;

    private void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isSolid = startSolid; // Set the initial state
        UpdatePlatformState();
    }

    public void Toggle()
    {
        isSolid = !isSolid;
        UpdatePlatformState();
        RotateButton();
    }

    private void UpdatePlatformState()
    {
        platformCollider.enabled = isSolid;
        spriteRenderer.sprite = isSolid ? solidSprite : nonSolidSprite;
    }

    private void RotateButton()
    {
        if (toggleButton != null)
        {
            // Rotate the button 180 degrees around the Z-axis
            toggleButton.transform.Rotate(0f, 180f, 0f);
        }
    }
}