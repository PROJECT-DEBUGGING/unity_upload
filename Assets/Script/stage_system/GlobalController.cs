using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Ȱ��ȭ�� ���� �ε��� ����(����)
    private int activeFileIndex = 0;
    public GameObject[] files;      //���� ���� ������Ʈ ���� �迭

    void Start()
    {
        UpdateFileActivation();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void UpdateFileActivation()
    {
        // ��� ������ ��Ȱ��ȭ
        DeactivateAllFiles();

        // ���� Ȱ��ȭ�� ���ϱ��� Ȱ��ȭ
        for (int i = 0; i <= activeFileIndex; i++) 
            files[i].SetActive(true);
        
    }

    void DeactivateAllFiles()
    {
        foreach (GameObject file in files)
        {
            file.SetActive(false);
        }
    }

    // ���� ������ �����ϴ� �Լ�
    public void SetActiveFileIndex(int index)
    {
        activeFileIndex = Mathf.Clamp(index, 0, files.Length - 1);
        // ������ Ȱ��ȭ ���� ������Ʈ
        UpdateFileActivation();
    }
}
