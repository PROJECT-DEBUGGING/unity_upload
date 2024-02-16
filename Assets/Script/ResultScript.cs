using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    public int PuzzleNo;
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
            Invoke("ClearSound", GetTime);
            GetTime += 2f;
            Invoke("HideClear", GetTime);
            Invoke("CanDebug", GetTime);
            result = 0;

            GlobalController.Instance.SetFileClearStatus(PuzzleNo, true);
        }
        else if (result == 2)//실패
        {
            CantDebug = false;
            ArrowScript NowArrow = GameObject.FindObjectOfType<ArrowScript>();
            GetTime = NowArrow.MoveTime;
            Debug.Log("result is 2 in resultscript");

            Invoke("FailedPuzzle", GetTime);
            Invoke("FailedSound", GetTime);
            GetTime += 2f;
            Invoke("HideFailed", GetTime);
            Invoke("CanDebug", GetTime);
            result = 0;

            GlobalController.Instance.SetFileClearStatus(PuzzleNo, false);
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
    public void ClearSound()
    {
        GameObject clear = GameObject.Find("clear_0");
        AudioSource clearsound = clear.GetComponent<AudioSource>();
        clearsound.Play();
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
    }
    public void FailedSound()
    {
        GameObject failed = GameObject.Find("failed_0");
        AudioSource failedsound = failed.GetComponent<AudioSource>();
        failedsound.Play();
    }
    public void HideFailed()
    {
        Transform FailScreen = transform.Find("failed_0");
        FailScreen.gameObject.SetActive(false);
    }
}
