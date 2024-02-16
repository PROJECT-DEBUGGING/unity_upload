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

            // 현재까지 클리어한 파일의 개수만큼 또는 isClear 배열이 true인 경우에만 활성화
            canvasGroup.alpha = (GlobalController.isClear[i]) ? 1f : 0f;
            canvasGroup.interactable = canvasGroup.blocksRaycasts = GlobalController.isClear[i];

            // 추가: alpha가 0f이고 그 전 파일이 클리어된 경우에 대한 처리
            if (canvasGroup.alpha == 0f)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
                break; // break를 사용하여 루프를 종료하도록 수정
            }
        }
    }

}

