using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    public int result = 0;

    // Update is called once per frame
    void Update()
    {
        if (result == 1)
        {
            Debug.Log("result is 1 in resultscript");
            Invoke("ClearPuzzle", 2f);
            Invoke("HideClear", 4f);
            result = 0;
        }
        else if (result == 2)
        {
            Debug.Log("result is 2 in resultscript");
            Invoke("FailedPuzzle", 2f);
            Invoke("HideFailed", 4f);
            result = 0;
        }
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
