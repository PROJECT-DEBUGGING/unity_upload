using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTouchEvent : MonoBehaviour//DebugTouchEvent�κ��� ��ũ��Ʈ �̸��� ���ƾ���
{
    
    public void OnClickButton()
    {   
        ResultScript resultScript = GameObject.FindObjectOfType<ResultScript>();
        if (resultScript.CantDebug)
        {
            AudioSource DebugAudio = GetComponent<AudioSource>();
            DebugAudio.Play();
            ArrowScript arsc = GameObject.FindObjectOfType<ArrowScript>();

            arsc.Starting();
        }
        else
        {
            Debug.Log("defend success");
        }
        
        
    }
}