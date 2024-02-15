using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    private static GlobalController instance;

    // Ŭ����� ���� ���� �迭
    static bool[] isClear = new bool[4];

    // ���� ���� ������Ʈ ���� �迭
    public GameObject[] puzzles;

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
        // Start���� �ʱ�ȭ
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

            // ������� Ŭ������ ������ ������ŭ �Ǵ� isClear �迭�� true�� ��쿡�� Ȱ��ȭ
            canvasGroup.alpha = (isClear[i]) ? 1f : 0f;
            canvasGroup.interactable = canvasGroup.blocksRaycasts = isClear[i];

            // �߰�: alpha�� 0f�̰� �� �� ������ Ŭ����� ��쿡 ���� ó��
            if (canvasGroup.alpha == 0f)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
                break; // break�� ����Ͽ� ������ �����ϵ��� ����
            }
        }
    }



    // ������ Ŭ���� ���� ����
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
