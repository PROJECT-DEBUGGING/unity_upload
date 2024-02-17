using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeeffect : MonoBehaviour
{
    private Image image;


    void Start()
    {
        image = GetComponent<Image>();
        SetImageTransparent();
        image.raycastTarget = false;
        StartCoroutine(FadeOutImage());
    }

    void Update()
    {
        // Update 내용 추가
    }

    private void SetImageTransparent()
    {
        Color color = image.color;
        color.a = 0f;
        image.color = color;
    }

    public void FadeInImage()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float duration = 2.0f;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - startTime) / duration);
            Color newColor = image.color;
            newColor.a = alpha;
            image.color = newColor;

            yield return null;
        }
    }

    IEnumerator FadeOutImage()
    {
        float duration = 2.0f;
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) / duration);
            Color newColor = image.color;
            newColor.a = alpha;
            image.color = newColor;

            yield return null;
        }
    }
}