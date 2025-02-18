using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class fallTrigger : MonoBehaviour
{
    public AudioClip deathSound;
    private AudioSource audioSource;
    public string sceneName = "mainMenu"; // Scene to load after player dies (you can set it to "Test" for replay)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the collider is Kirby
        {
            // Trigger lose screen
             if (deathSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(deathSound); // Play death sound once
            }
            LoseGame();
        }
    }

    void LoseGame()
    {
        SceneManager.LoadScene("loseScreen");
        Time.timeScale = 0f; 
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene("Test"); // Reload the scene to restart
    }
}
