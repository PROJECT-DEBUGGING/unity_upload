using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTouchEvent : MonoBehaviour//DebugTouchEvent부분은 스크립트 이름과 같아야함
{
    void Start()
    {
        Debug.Log("시작");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);//physics명령어 사용, 클릭 상호작용 가능한 오브젝트에 컴포넌트 넣어야함.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}