using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

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
            uiImage.raycastTarget = false;

            uiImage.color = newColor;
        }
    }


    [YarnCommand("StartFadeInNPCImage")]
    public void StartFadeInNPCImage(Image ImageName)
    {
        StartCoroutine(FadeInImage(ImageName));
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
    public void StartFadeOutNPCImage(Image ImageName)
    {
         StartCoroutine(FadeOutImage(ImageName));
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

    [YarnCommand("ImageOff")]
    public void ImgOff(Image ImageName)
    {
        StartCoroutine(OFFImage(ImageName));
    }
    IEnumerator OFFImage(Image targetImage)
    {
        Color newColor = targetImage.color;
        newColor.a = 0f; 
        targetImage.raycastTarget = false;
        targetImage.color = newColor;

        yield return null;
    }

    [YarnCommand("ImageOn")]
    public void ImgOn(Image ImageName)
    {
        StartCoroutine(ONImage(ImageName));
    }
    IEnumerator ONImage(Image targetImage)
    {
        Color newColor = targetImage.color;
        newColor.a = 1f;
        targetImage.color = newColor;

        yield return null;
    }


    [YarnCommand("ChangeScene")]
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    //[YarnCommand("GetDayNum")]
    //public static int GetDayNumber()
    //{
    //    int dayNumber = 0;
    //    // Parse the dayFlags and perform necessary logic
    //    bool day1 = bool.Parse(dayFlags[0]);
    //    bool day2 = bool.Parse(dayFlags[1]);
    //    bool day3 = bool.Parse(dayFlags[2]);
    //    bool day4 = bool.Parse(dayFlags[3]);

    //    // Your logic here to calculate the day number

    //    return dayNumber; // Return the calculated day number
    //}
}