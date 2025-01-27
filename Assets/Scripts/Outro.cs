using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private float fadeDuration = 2f;

    private void OnEnable()
    {
        StartCoroutine(RunOutro());
    }

    private IEnumerator RunOutro()
    {
        yield return new WaitForSeconds(1f); 

        // Emotional epic message
        textMeshPro.text = "What matters is your journey. \r\n\r\nFind yourself and keep going <33 \r\n\r\nThanks for playing!";
        yield return StartCoroutine(FadeText(0f, 1f)); 
        yield return StartCoroutine(FadeBackground(0f, 1f)); 

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(FadeText(1f, 0f));

        // epic team credits
        textMeshPro.text = "Developed by Bubble Trouble";

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(FadeText(0f, 1f)); 

        yield return new WaitForSeconds(1f); 

        yield return StartCoroutine(FadeText(1f, 0f)); 

        yield return new WaitForSeconds(1f);

        // Load the scene from the start
        SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator FadeText(float startTransparency, float endTransparency)
    {
        float counter = 0f;
        Color color = textMeshPro.color;

        color.a = startTransparency;
        textMeshPro.color = color;

        while (counter < fadeDuration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(startTransparency, endTransparency, counter / fadeDuration);

            color.a = alpha;
            textMeshPro.color = color;

            yield return null;
        }

        color.a = endTransparency;
        textMeshPro.color = color;
    }

    private IEnumerator FadeBackground(float startTransparency, float endTransparency)
    {
        float counter = 0f;
        Color color = backgroundImage.color;

        color.a = startTransparency;
        backgroundImage.color = color;

        while (counter < fadeDuration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(startTransparency, endTransparency, counter / fadeDuration);

            color.a = alpha;
            backgroundImage.color = color;

            yield return null;
        }

        color.a = endTransparency;
        backgroundImage.color = color;
    }
}
