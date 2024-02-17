using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    private static GlobalController instance;

    // Ŭ����� ���� ���� �迭
    public static bool[] isClear = new bool[4];
    public static bool beforepuzzle = true;
    public static int SelectedNum = 0;

    // ���� ���� ������Ʈ ���� �迭
    

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
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
       
        
    }

    void Update()
    {

    }

  
    // ������ Ŭ���� ���� ����
    public void SetFileClearStatus(int fileIndex, bool isFileCleared)
    {
        if (fileIndex >= 0 && fileIndex < isClear.Length)
        {
            isClear[fileIndex] = isFileCleared;
            //Debug.Log(fileIndex + "�� ����");
            //Debug.Log(isFileCleared + " ����");
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
