using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTouchEvent : MonoBehaviour//DebugTouchEvent부분은 스크립트 이름과 같아야함
{
    
    public void OnClickButton()
    {
        ArrowScript arsc = GameObject.FindObjectOfType<ArrowScript>();
        
        arsc.Starting();
        
    }
}