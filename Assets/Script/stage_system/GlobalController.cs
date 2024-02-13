using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private static NewBehaviourScript instance;

    // 클리어된 파일 개수
    private int clearedFileCount = 0;

    // 파일 게임 오브젝트 저장 배열
    public GameObject[] files;

    // 싱글톤 인스턴스 가져오기
    [System.Obsolete]
    public static NewBehaviourScript Instance
    {
        get
        {
            if (instance == null)
            {
                // 씬에 이미 존재하는지 확인
                instance = FindObjectOfType<NewBehaviourScript>();

                if (instance == null)
                {
                    // 없으면 새로 생성
                    GameObject singletonObject = new GameObject("NewBehaviourScriptSingleton");
                    instance = singletonObject.AddComponent<NewBehaviourScript>();
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
        SetClearedFileCount();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void UpdateFileActivation()
    {
        for (int i = 0; i < files.Length; i++)
        {
            CanvasGroup canvasGroup = files[i].GetComponent<CanvasGroup>();
            if (canvasGroup == null)
                canvasGroup = files[i].AddComponent<CanvasGroup>();

            // 현재까지 클리어한 파일의 개수만큼 활성화
            canvasGroup.alpha = (i <= clearedFileCount) ? 1f : 0f;
            canvasGroup.interactable = canvasGroup.blocksRaycasts = (i <= clearedFileCount);
        }
    }

    // 클리어된 파일 개수 조정
    public void SetClearedFileCount(int count = 0)
    {
        clearedFileCount = Mathf.Clamp(count, 0, files.Length);
        UpdateFileActivation();
    }
}
