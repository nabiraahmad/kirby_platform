using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string nextLevelName; // Set this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerInventory.hasKey)
        {
            SceneManager.LoadScene(nextLevelName); // Load the next level
        }
    }
}