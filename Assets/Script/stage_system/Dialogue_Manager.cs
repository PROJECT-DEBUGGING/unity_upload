using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using System.Collections;
using UnityEngine.SceneManagement;

public class NPC_Image : MonoBehaviour
{
    public Image[] uiImages;


    void Start()
    {
        // ��ŸƮ�� �� ��� �̹����� �ʱ�ȭ
        foreach (Image uiImage in uiImages)
        {
            Color newColor = uiImage.color;
            newColor.a = 0f; // ����
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
        float duration = 1.0f; // ���̵� ���ϴ� �� �ɸ��� �ð�
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
        float duration = 1.0f; // ���̵� �ƿ��ϴ� �� �ɸ��� �ð�
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



    [YarnCommand("ChangeScene")]
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }




    [YarnCommand("GetDayNum")]
    public static void GetDayNumber()
    {
        
    }
}