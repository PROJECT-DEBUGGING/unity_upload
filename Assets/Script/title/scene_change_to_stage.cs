using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class YourClickHandlerScript : MonoBehaviour { 

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider != null)
            {
                // ��ư�� Ŭ���Ǹ� �� ��ȯ
                SceneManager.LoadScene("Stage_Selection_Scene");
            }
        }
    }
}