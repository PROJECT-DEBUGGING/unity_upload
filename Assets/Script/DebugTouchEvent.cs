using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTouchEvent : MonoBehaviour//DebugTouchEvent�κ��� ��ũ��Ʈ �̸��� ���ƾ���
{
    
    public void OnClickButton()
    {
        ArrowScript arsc = GameObject.FindObjectOfType<ArrowScript>();
        
        arsc.Starting();
        
    }
}