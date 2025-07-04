using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    void Start()
    {
        globalController = GlobalController.Instance;
    }

    public int PuzzleNo;
    public int result = 0;
    public float GetTime;
    public Boolean CantDebug = true;
    public GlobalController globalController;

    void Update()
    {
        if (result == 1)//성공
        {
            GlobalController.Instance.SetFileClearStatus(PuzzleNo, true);
            Debug.Log("수정" + PuzzleNo);

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

            globalController.SaveData();

        }
        else if (result == 2)//실패
        {

            GlobalController.Instance.SetFileClearStatus(PuzzleNo, false);

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
        SceneManager.LoadScene("Day_Scene");
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
