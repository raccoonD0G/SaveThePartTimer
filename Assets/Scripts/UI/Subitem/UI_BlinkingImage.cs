using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingImage : MonoBehaviour
{
    public Image imageToBlink;
    public float blinkDuration;

    void Start()
    {
        blinkDuration = 0.3f;
    }

    private void OnEnable()
    {
        imageToBlink = gameObject.GetComponent<Image>();
        StartCoroutine(BlinkImage());
    }

    IEnumerator BlinkImage()
    {
        while (true)
        {
            yield return StartCoroutine(FadeImage(true));
            yield return new WaitForSeconds(blinkDuration);
            yield return StartCoroutine(FadeImage(false));
            yield return new WaitForSeconds(blinkDuration);
        }
    }

    IEnumerator FadeImage(bool fadeIn)
    {
        float targetAlpha = fadeIn ? 1.0f : 0.0f;
        while (!Mathf.Approximately(imageToBlink.color.a, targetAlpha))
        {
            float newAlpha = Mathf.MoveTowards(imageToBlink.color.a, targetAlpha, Time.deltaTime / blinkDuration);
            imageToBlink.color = new Color(imageToBlink.color.r, imageToBlink.color.g, imageToBlink.color.b, newAlpha);
            yield return null;
        }
    }
}
