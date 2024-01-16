using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0.5f;
    public float pauseTime = 1f;
    void Start()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        // 찾은 하위 오브젝트의 활성화 여부 변경
        whitearrow.gameObject.SetActive(true); // 또는 false로 설정
        redarrow.gameObject.SetActive(false); // 또는 false로 설정
        yellowarrow.gameObject.SetActive(false); // 또는 false로 설정
        bluearrow.gameObject.SetActive(false); // 또는 false로 설정

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)){ Change(0); }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) { Change(1); }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { Change(2); }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { Change(3); }

        //화살표 이동 명령어
        InvokeRepeating("MoveObjects", 0f, moveSpeed + pauseTime);
        
    }
    void MoveObjects()
    {
        foreach (Transform child in transform)
        {
            // 현재 위치에서 목표 위치까지 이동
            Vector2 currentPosition = child.position;
            Vector2 targetPosition = new Vector2(currentPosition.x, currentPosition.y - 0.5f);
            child.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    void Change(int color)//0 1 2 3 값따라 화살표 색 변경
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");
        if (color == 0)//white
        {
            whitearrow.gameObject.SetActive(true); // 또는 false로 설정
            redarrow.gameObject.SetActive(false); // 또는 false로 설정
            yellowarrow.gameObject.SetActive(false); // 또는 false로 설정
            bluearrow.gameObject.SetActive(false); // 또는 false로 설정
        }
        else if (color == 1)//red
        {
            whitearrow.gameObject.SetActive(false); // 또는 false로 설정
            redarrow.gameObject.SetActive(true); // 또는 false로 설정
            yellowarrow.gameObject.SetActive(false); // 또는 false로 설정
            bluearrow.gameObject.SetActive(false); // 또는 false로 설정
        }
        else if (color == 2)//yellow
        {
            whitearrow.gameObject.SetActive(false); // 또는 false로 설정
            redarrow.gameObject.SetActive(false); // 또는 false로 설정
            yellowarrow.gameObject.SetActive(true); // 또는 false로 설정
            bluearrow.gameObject.SetActive(false); // 또는 false로 설정
        }
        else if (color == 3)//blue
        {
            whitearrow.gameObject.SetActive(false); // 또는 false로 설정
            redarrow.gameObject.SetActive(false); // 또는 false로 설정
            yellowarrow.gameObject.SetActive(false); // 또는 false로 설정
            bluearrow.gameObject.SetActive(true); // 또는 false로 설정
        }
    } 
}
