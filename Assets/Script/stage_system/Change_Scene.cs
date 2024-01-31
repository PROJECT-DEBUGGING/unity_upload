using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene("Stage_Selection_Scene");
                break;
            case BTNType.End:
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
                break;
            
        }
    }
}

public class YourClickHandlerScript : MonoBehaviour { 

    void Start()
    {

    }
    void Update()
    {
       
    }

}