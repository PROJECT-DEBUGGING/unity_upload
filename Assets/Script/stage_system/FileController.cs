using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileController : MonoBehaviour
{
    public GameObject[] puzzles;
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < GlobalController.isClear.Length; i++)
        {
            CanvasGroup canvasGroup = puzzles[i].GetComponent<CanvasGroup>();

            GlobalController.isClear[i] = false;
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
        }

        UpdateFileActivation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void UpdateFileActivation()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            Debug.Log(i);
            CanvasGroup canvasGroup = puzzles[i].GetComponent<CanvasGroup>();
            if (canvasGroup == null)
                canvasGroup = puzzles[i].AddComponent<CanvasGroup>();

            // ������� Ŭ������ ������ ������ŭ �Ǵ� isClear �迭�� true�� ��쿡�� Ȱ��ȭ
            canvasGroup.alpha = (GlobalController.isClear[i]) ? 1f : 0f;
            canvasGroup.interactable = canvasGroup.blocksRaycasts = GlobalController.isClear[i];

            // �߰�: alpha�� 0f�̰� �� �� ������ Ŭ����� ��쿡 ���� ó��
            if (canvasGroup.alpha == 0f)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
                break; // break�� ����Ͽ� ������ �����ϵ��� ����
            }
        }
    }

}

