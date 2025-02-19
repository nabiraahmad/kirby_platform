using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string nextLevelName; // Set this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerInventory.hasKey)
        {
            string lastLevel = PlayerPrefs.GetString("LastLevel", "Test");

            if (lastLevel == "lvl2")
            {
                // If they just completed lvl2, send them to the Win Screen
                SceneManager.LoadScene("winScreen");
            }
            else
            {
                // Otherwise, go to the transition scene
                PlayerPrefs.SetString("LastLevel", "lvl2"); // Save progress
                PlayerPrefs.Save();

                SceneManager.LoadScene("transitionScene");
            }
        }
    }
}