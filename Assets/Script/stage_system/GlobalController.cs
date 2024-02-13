using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private static NewBehaviourScript instance;

    // Ŭ����� ���� ����
    private int clearedFileCount = 0;

    // ���� ���� ������Ʈ ���� �迭
    public GameObject[] files;

    // �̱��� �ν��Ͻ� ��������
    [System.Obsolete]
    public static NewBehaviourScript Instance
    {
        get
        {
            if (instance == null)
            {
                // ���� �̹� �����ϴ��� Ȯ��
                instance = FindObjectOfType<NewBehaviourScript>();

                if (instance == null)
                {
                    // ������ ���� ����
                    GameObject singletonObject = new GameObject("NewBehaviourScriptSingleton");
                    instance = singletonObject.AddComponent<NewBehaviourScript>();
                }
            }

            return instance;
        }
    }
    void Awake()
    {
        // �ٸ� ��ũ��Ʈ���� �̱����� ������ �� �ֵ��� ����
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

            // ������� Ŭ������ ������ ������ŭ Ȱ��ȭ
            canvasGroup.alpha = (i <= clearedFileCount) ? 1f : 0f;
            canvasGroup.interactable = canvasGroup.blocksRaycasts = (i <= clearedFileCount);
        }
    }

    // Ŭ����� ���� ���� ����
    public void SetClearedFileCount(int count = 0)
    {
        clearedFileCount = Mathf.Clamp(count, 0, files.Length);
        UpdateFileActivation();
    }
}
