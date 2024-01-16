using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTouchEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);//physics명령어 사용, 클릭 상호작용 가능한 오브젝트에 컴포넌트 넣어야함.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Moveable_Button"))
                {
                    Debug.Log("이동가능블록");
                    // 플레이어에 대한 추가 동작을 수행
                }
                else if (hit.collider.CompareTag("Fixed_Button"))
                {
                    Debug.Log("이동불가능블록");
                    // 적에 대한 추가 동작을 수행
                }

            }
        }
    }
}
