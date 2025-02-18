using UnityEngine;
using UnityEngine.SceneManagement; // To load scenes

public class LoseScreen : MonoBehaviour
{

    // Method to handle replaying the game, which reloads the main level
    public void ReplayGame()
    {
        SceneManager.LoadScene("Test"); // Make sure to replace "Test" with your level name
    }

}
