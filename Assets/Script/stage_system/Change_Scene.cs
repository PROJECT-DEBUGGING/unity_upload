using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public fadeeffect fadeEffect;
    public void OnBtnClick()
    {
        
 
        switch (currentType)
        {
            case BTNType.Start:
                SoundManager.instance.PlaySE("start_b");
                SceneManager.LoadScene("Stage_Selection_Scene");
                break;

            case BTNType.End:
                SoundManager.instance.PlaySE("quit_b");
                Debug.Log("게임종료");
                Application.Quit();

                break;
            case BTNType.File1:
                GlobalController.ChangeSelectedNum(0);
                SoundManager.instance.PlaySE("file_b");

                fadeEffect.FadeInImage();
                StartCoroutine(WaitAndDoSomething());

                SceneManager.LoadScene("Day_Scene");

                break;
            case BTNType.File2:
                GlobalController.ChangeSelectedNum(1);
                SoundManager.instance.PlaySE("file_b");

                fadeEffect.FadeInImage();
                StartCoroutine(WaitAndDoSomething());


                SceneManager.LoadScene("Day_Scene");

                break;
            case BTNType.File3:
                GlobalController.ChangeSelectedNum(2);
                SoundManager.instance.PlaySE("file_b");

                fadeEffect.FadeInImage();
                StartCoroutine(WaitAndDoSomething());

                SceneManager.LoadScene("Day_Scene");

                break;
            case BTNType.File4:
                GlobalController.ChangeSelectedNum(3);
                SoundManager.instance.PlaySE("file_b");

                fadeEffect.FadeInImage();
                StartCoroutine(WaitAndDoSomething());

                SceneManager.LoadScene("Day_Scene");

                break;


            case BTNType.Return:
                // 현재 씬에 따라 다른 씬으로 이동
                string currentScene = SceneManager.GetActiveScene().name;
                switch (currentScene)
                {
                    case "Stage_Selection_Scene":
                        SceneManager.LoadScene("Title_Scene");
                        break;
                    case "Day1_Puzzle_Scene":
                    case "Day2_Puzzle_Scene":
                    case "Day3_Puzzle_Scene":
                    case "Day4_Puzzle_Scene":
                        GlobalController.beforepuzzle = true;
                        SceneManager.LoadScene("Stage_Selection_Scene");
                        break;
                        
                }
                break;
        }

        
    }

    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(2f); // 2초 동안 기다립니다.
        Debug.Log("After waiting for 1 second. Now do something!");
    }


}