// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class mainMenu : MonoBehaviour
// {
//     public void PlayGame()
//     {
//         SceneManager.LoadScene("Test"); 
//     }
//     public void onRetryClick()
//     {
//         if (SceneManager.GetActiveScene().name == "lvl2")
//         {
//             SceneManager.LoadScene("lvl2"); 
//         }
//         else
//         {
//             SceneManager.LoadScene("mainMenu"); 
//         }
//     }

// }

using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Test"); // Start Level 1
    }

    public void onRetryClick()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel", "MainMenu"); // Get last level, default to MainMenu
        if (SceneManager.GetActiveScene().name == "winScreen"){
            SceneManager.LoadScene("mainMenu");
        }
        else if (lastLevel == "lvl2")
        {
            SceneManager.LoadScene("lvl2"); // Restart Level 2 if it was the last active level
        }
        else
        {
            SceneManager.LoadScene("Test"); // Otherwise, restart Level 1
        }
    }
    public void LoseGame()
    {
        string currentLevel = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastLevel", currentLevel);
        PlayerPrefs.Save(); // Save the last played level

        Debug.Log("Saved LastLevel: " + currentLevel); // Debugging log

        SceneManager.LoadScene("LoseScreen"); // Load Lose Screen
    }
}
