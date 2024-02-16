using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BTNType
{
    Start,
    End,
    Return,
    File1,
    File2,
    File3,
    File4
}

public class BTN : MonoBehaviour
{
    public BTNType currentType;
   

    public void OnBtnClick()
    {
        
        switch (currentType)
        {
            case BTNType.Start:
                SoundManager.instance.PlaySE(GetComponent<Button>());
                SceneManager.LoadScene("Stage_Selection_Scene");
                break;
            case BTNType.End:
                SoundManager.instance.PlaySE(GetComponent<Button>());
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
                break;
            case BTNType.File1:
            case BTNType.File2:
            case BTNType.File3:
            case BTNType.File4:
                SoundManager.instance.PlaySE(GetComponent<Button>());
                SceneManager.LoadScene("Day_Scene");
                break;


            case BTNType.Return:
                // ���� ���� ���� �ٸ� ������ �̵�
                string currentScene = SceneManager.GetActiveScene().name;
                switch (currentScene)
                {
                    case "Stage_Selection_Scene":
                        SceneManager.LoadScene("Title_Scene");
                        break;
                    //case "Scene2":
                    //    SceneManager.LoadScene("ReturnScene2");
                      //  break;
                        // �ٸ� ���鿡 ���� ó���� �߰� ����
                }
                break;
        }

    }

  


}