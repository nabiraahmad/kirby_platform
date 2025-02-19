using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Test"); 
    }
    public void OnRetryClick()
    {
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
    }

}
