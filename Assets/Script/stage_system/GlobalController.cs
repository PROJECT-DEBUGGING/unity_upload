using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // 활성화된 파일 인덱스 저장(전역)
    private int activeFileIndex = 0;
    public GameObject[] files;      //파일 게임 오브젝트 저장 배열

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
        // 모든 파일을 비활성화
        DeactivateAllFiles();

        // 현재 활성화된 파일까지 활성화
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

    // 전역 변수를 조정하는 함수
    public void SetActiveFileIndex(int index)
    {
        activeFileIndex = Mathf.Clamp(index, 0, files.Length - 1);
        // 파일의 활성화 여부 업데이트
        UpdateFileActivation();
    }
}
