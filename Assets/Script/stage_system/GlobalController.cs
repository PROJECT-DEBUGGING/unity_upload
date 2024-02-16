using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    private static GlobalController instance;

    // 클리어된 파일 여부 배열
    public static bool[] isClear = new bool[4];
    public static bool beforepuzzle = true;
    public static int SelectedNum = 0;

    // 파일 게임 오브젝트 저장 배열
    

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
        
    }

    void Update()
    {

    }

  
    // 파일의 클리어 여부 설정
    public void SetFileClearStatus(int fileIndex, bool isFileCleared)
    {
        if (fileIndex >= 0 && fileIndex < isClear.Length)
        {
            isClear[fileIndex] = isFileCleared;
        }
        else
        {
            Debug.LogError("Invalid fileIndex: " + fileIndex);
        }
    }

    public void CheckInGame(bool state)
    {
        beforepuzzle = state;
    }

    public static void ChangeSelectedNum(int num)
    {
        SelectedNum = num;
    }

}
