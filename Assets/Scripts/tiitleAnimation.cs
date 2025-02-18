using System.Collections;
using TMPro;
using UnityEngine;

public class titleAnimation : MonoBehaviour
{
    public TextMeshProUGUI titleText;  
    public float delay = 0.2f; // Delay between letters appearing

    private void Start()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        string fullText = titleText.text;  
        titleText.text = "";  // Clear the text at the start

        for (int i = 0; i < fullText.Length; i++)
        {
            titleText.text += fullText[i];  
            yield return new WaitForSeconds(delay);  // Wait before adding the next letter
        }
    }
}
