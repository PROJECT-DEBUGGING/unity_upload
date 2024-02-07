using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using System.Collections;

public class NPC_Image : MonoBehaviour
{
    public Image[] uiImages;


    void Start()
    {
        // 스타트할 때 모든 이미지를 초기화
        foreach (Image uiImage in uiImages)
        {
            Color newColor = uiImage.color;
            newColor.a = 0f; // 투명
            uiImage.color = newColor;
        }
    }


    [YarnCommand("StartFadeInNPCImage")]
    public void StartFadeInNPCImage(string UIName)
    {
        Image targetImage = FindImage(UIName);
        if (targetImage != null)
        {
            // 페이드 인 애니메이션 시작
            StartCoroutine(FadeInImage(targetImage));
        }
        else
        {
            Debug.LogError("Image not found!");
        }
    }

    Image FindImage(string UIName)
    {
        // UIName과 일치하는 Image 찾기
        foreach (Image uiImage in uiImages)
        {
            if (uiImage.name == UIName)
            {
                return uiImage;
            }
        }
        return null;
    }

    IEnumerator FadeInImage(Image targetImage)
    {
        float duration = 1.0f; // 페이드 인하는 데 걸리는 시간
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, (Time.time - startTime) / duration);
            Color newColor = targetImage.color;
            newColor.a = alpha;
            targetImage.color = newColor;

            yield return null;
        }
    }

    [YarnCommand("StartFadeOutNPCImage")]
    public void StartFadeOutNPCImage(string UIName)
    {
        Image targetImage = FindImage(UIName);
        if (targetImage != null)
        {
            // 이미지 페이드 아웃 애니메이션 시작
            StartCoroutine(FadeOutImage(targetImage));
        }
        else
        {
            Debug.LogError("Image not found!");
        }
    }

    IEnumerator FadeOutImage(Image targetImage)
    {
        float duration = 1.0f; // 페이드 아웃하는 데 걸리는 시간
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) / duration);
            Color newColor = targetImage.color;
            newColor.a = alpha;
            targetImage.color = newColor;

            yield return null;
        }
    }
}