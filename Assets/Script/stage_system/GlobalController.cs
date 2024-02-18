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

    // Ŭ����� ���� ���� �迭
    public static bool[] isClear = new bool[4];
    public static bool beforepuzzle = true;
    public static int SelectedNum = 0;

    string path;
    string filename = "save";

    // �̱��� �ν��Ͻ� ��������
    [System.Obsolete]
    public static GlobalController Instance
    {
        get
        {
            if (instance == null)
            {
                // ���� �̹� �����ϴ��� Ȯ��
                instance = FindObjectOfType<GlobalController>();

                if (instance == null)
                {
                    // ������ ���� ����
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
        // ����� ������ �ִٸ� �ε�
        if (File.Exists(GetFullPath()))
        {
            LoadData();
        }
        else
        {
            // ������ ���ٸ� �ʱ� �����͸� ����
            SaveData();
        }
    }

    void Update()
    {
        // �߰����� ������Ʈ ������ �ʿ��ϴٸ� �ۼ�
    }

    // ������ Ŭ���� ���� ����
    public void SetFileClearStatus(int fileIndex, bool isFileCleared)
    {
        if (fileIndex >= 0 && fileIndex < isClear.Length)
        {
            isClear[fileIndex] = isFileCleared;
            SaveData(); // ����� �����͸� ����
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
        // SaveData Ŭ������ �ν��Ͻ� ����
        SaveData saveData = new SaveData(isClear);

        // ����ȭ�� �����͸� ���� �� ����
        string serializedData = JsonUtility.ToJson(saveData);

        // ���Ŀ� serializedData�� ����
        File.WriteAllText(GetFullPath(), serializedData);
    }

    public void LoadData()
    {
        // �ε��� �����͸� �о��
        string serializedData = File.ReadAllText(GetFullPath());

        // ����ȭ�� �����͸� �ٽ� SaveData Ŭ������ �ν��Ͻ��� ��ȯ
        SaveData saveData = JsonUtility.FromJson<SaveData>(serializedData);

        // isClear ���� �����͸� ����
        isClear = saveData.isClear;
    }

    private string GetFullPath()
    {
        return Path.Combine(path, filename);
    }
}