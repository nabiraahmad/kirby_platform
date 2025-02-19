using UnityEngine;
using TMPro;
using System.Collections;

public class WaitMessage : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = popupText.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = popupText.gameObject.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0; // Start fully invisible
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(FadeText(1)); // Fade in
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(FadeText(0)); // Fade out
        }
    }

    IEnumerator FadeText(float targetAlpha)
    {
        while (!Mathf.Approximately(canvasGroup.alpha, targetAlpha))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, Time.deltaTime * 2);
            yield return null;
        }
    }
}

// using UnityEngine;
// using UnityEngine.UI;

// public class WaitMessage : MonoBehaviour
// {
//     public GameObject popupText; 

//     void Start()
//     {
//         popupText.SetActive(false); 
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("Trigger Entered! Showing text.");
//             popupText.SetActive(true); 
//         }
//     }

//     void HideMessage()
//     {
//         popupText.SetActive(false);
//     }
// }

