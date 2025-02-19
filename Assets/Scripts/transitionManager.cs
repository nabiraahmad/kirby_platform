using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transitionManager : MonoBehaviour
{
    public Button start2Button; 
    public Button replayButton; 

    void Start()
    {
        start2Button.onClick.AddListener(StartLevel2);
        replayButton.onClick.AddListener(GoToMainMenu);
    }

    void StartLevel2()
    {
        SceneManager.LoadScene("lvl2");
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
