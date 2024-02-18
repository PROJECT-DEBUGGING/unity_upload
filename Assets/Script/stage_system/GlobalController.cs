using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class SaveData
{
    public bool[] isClear;

    public SaveData(bool[] isClear)
    {
        this.isClear = isClear;
    }
}

public class GlobalController : MonoBehaviour
{
    private static GlobalController instance;

    // 클리어된 파일 여부 배열
    public static bool[] isClear = new bool[4];
    public static bool beforepuzzle = true;
    public static int SelectedNum = 0;

    string path;
    string filename = "save";

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
                    for (int i = 0; i < GlobalController.isClear.Length; i++)
                    {
                        GlobalController.isClear[i] = false;
                    }
                }
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            path = Application.persistentDataPath + "/";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 저장된 파일이 있다면 로드
        if (File.Exists(GetFullPath()))
        {
            LoadData();
        }
        else
        {
            // 파일이 없다면 초기 데이터를 저장
            SaveData();
        }
    }

    void Update()
    {
        // 추가적인 업데이트 로직이 필요하다면 작성
    }

    // 파일의 클리어 여부 설정
    public void SetFileClearStatus(int fileIndex, bool isFileCleared)
    {
        if (fileIndex >= 0 && fileIndex < isClear.Length)
        {
            isClear[fileIndex] = isFileCleared;
            SaveData(); // 변경된 데이터를 저장
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

    public void SaveData()
    {
        // SaveData 클래스의 인스턴스 생성
        SaveData saveData = new SaveData(isClear);

        // 직렬화된 데이터를 얻어올 수 있음
        string serializedData = JsonUtility.ToJson(saveData);

        // 이후에 serializedData를 저장
        File.WriteAllText(GetFullPath(), serializedData);
    }

    public void LoadData()
    {
        // 로드할 데이터를 읽어옴
        string serializedData = File.ReadAllText(GetFullPath());

        // 직렬화된 데이터를 다시 SaveData 클래스의 인스턴스로 변환
        SaveData saveData = JsonUtility.FromJson<SaveData>(serializedData);

        // isClear 등의 데이터를 복원
        isClear = saveData.isClear;
    }

    private string GetFullPath()
    {
        return Path.Combine(path, filename);
    }
}