using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    public int result = 0;
    public float GetTime;
    public Boolean CantDebug = true;
    void Update()
    {
        if (result == 1)//성공
        {
            CantDebug = false;
            ArrowScript NowArrow = GameObject.FindObjectOfType<ArrowScript>();
            GetTime = NowArrow.MoveTime;
            Debug.Log("result is 1 in resultscript");
            
            Invoke("ClearPuzzle", GetTime);
            GetTime += 2f;
            Invoke("HideClear", GetTime);
            Invoke("CanDebug", GetTime);
            result = 0;
        }
        else if (result == 2)//실패
        {
            CantDebug = false;
            ArrowScript NowArrow = GameObject.FindObjectOfType<ArrowScript>();
            GetTime = NowArrow.MoveTime;
            Debug.Log("result is 2 in resultscript");
            
            Invoke("FailedPuzzle", GetTime);
            GetTime += 2f;
            Invoke("HideFailed", GetTime);
            Invoke("CanDebug", GetTime);
            result = 0;
        }
        GetTime = 0;
        ArrowScript arr = GameObject.FindObjectOfType<ArrowScript>();
        arr.MoveTime = 0;
    }
    public void CanDebug()
    {
        CantDebug = true;
    }
    public void ClearPuzzle()
    {
        Transform ClearScreen = transform.Find("clear_0");
        ClearScreen.gameObject.SetActive(true);
    }

    public void HideClear()
    {
        Transform ClearScreen = transform.Find("clear_0");
        ClearScreen.gameObject.SetActive(false);
    }
    public void FailedPuzzle()
    {
        Transform FailScreen = transform.Find("failed_0");
        FailScreen.gameObject.SetActive(true);
        Debug.Log("fail!");
    }

    public void HideFailed()
    {
        Transform FailScreen = transform.Find("failed_0");
        FailScreen.gameObject.SetActive(false); 
        Debug.Log("fail cut");
    }
}
