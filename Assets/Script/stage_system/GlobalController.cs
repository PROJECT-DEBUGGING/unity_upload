using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    private static GlobalController instance;

    // 클리어된 파일 여부 배열
    static bool[] isClear = new bool[4];

    // 파일 게임 오브젝트 저장 배열
    public GameObject[] puzzles;

    // 싱글톤 인스턴스 가져오기
    [System.Obsolete]
    public static GlobalController Instance
    {
        get
        {
            if (instance == null)
            {
                // 씬에 이미 존재하는지 확인
                instance = FindObjectOfType<GlobalController>();

                if (instance == null)
                {
                    // 없으면 새로 생성
                    GameObject singletonObject = new GameObject("NewBehaviourScriptSingleton");
                    instance = singletonObject.AddComponent<GlobalController>();
                }
            }

            return instance;
        }
    }

    void Awake()
    {
        // 다른 스크립트에서 싱글톤을 참조할 수 있도록 설정
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        // Start에서 초기화
        for (int i = 0; i < isClear.Length; i++)
        {
            CanvasGroup canvasGroup = puzzles[i].GetComponent<CanvasGroup>();

            isClear[i] = false;
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
            canvasGroup.alpha = (isClear[i]) ? 1f : 0f;
            canvasGroup.interactable = canvasGroup.blocksRaycasts = isClear[i];

            // 추가: alpha가 0f이고 그 전 파일이 클리어된 경우에 대한 처리
            if (canvasGroup.alpha == 0f)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
                break; // break를 사용하여 루프를 종료하도록 수정
            }
        }
    }



    // 파일의 클리어 여부 설정
    public void SetFileClearStatus(int fileIndex, bool isFileCleared)
    {
        if (fileIndex >= 0 && fileIndex < isClear.Length)
        {
            isClear[fileIndex] = isFileCleared;
            UpdateFileActivation();
        }
        else
        {
            Debug.LogError("Invalid fileIndex: " + fileIndex);
        }
    }

}
