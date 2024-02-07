using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using System.Collections;

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
    public void StartFadeInNPCImage(string UIName)
    {
        Image targetImage = FindImage(UIName);
        if (targetImage != null)
        {
            // ���̵� �� �ִϸ��̼� ����
            StartCoroutine(FadeInImage(targetImage));
        }
        else
        {
            Debug.LogError("Image not found!");
        }
    }

    Image FindImage(string UIName)
    {
        // UIName�� ��ġ�ϴ� Image ã��
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
    public void StartFadeOutNPCImage(string UIName)
    {
        Image targetImage = FindImage(UIName);
        if (targetImage != null)
        {
            // �̹��� ���̵� �ƿ� �ִϸ��̼� ����
            StartCoroutine(FadeOutImage(targetImage));
        }
        else
        {
            Debug.LogError("Image not found!");
        }
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
}