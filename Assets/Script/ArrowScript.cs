using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float pauseTime = 1f;//화살표의 움직임 사이의 시간. 1초
    public Boolean start = false;//디버그 버튼 눌릴 때 참이됨. 시작 여부
    public Boolean Arrowgo = true;//while을 벗어나게 함
    public Boolean IsClear = false;
    public BlockTouchEvent NowBlock;//진행 시 자신 옆의 블록
    public BlockTouchEvent InBlock;//만약 리피트, 이프 블록일 시 내부의 명령어 수행

    public float MoveTime = 2f;
    private Stack<int> ColorStack; // 스택
    private int NowColor;
    void Start()
    {
        ColorStack = new Stack<int>();
        NowColor = 0;
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        NowBlock = GameObject.Find("Start").GetComponent<BlockTouchEvent>();
        
        // 찾은 하위 오브젝트의 활성화 여부 변경
        whitearrow.gameObject.SetActive(true); // 또는 false로 설정
        redarrow.gameObject.SetActive(false); // 또는 false로 설정
        yellowarrow.gameObject.SetActive(false); // 또는 false로 설정
        bluearrow.gameObject.SetActive(false); // 또는 false로 설정       
    }
    /// <summary>
    /// start moving arrow
    /// </summary>
    public void MoveObjects()
    {
        int todo = (int) NowBlock.feature;//enum으로 주어진 블록의 특징 int로 변환
        Debug.Log(todo);
        DoBlock(todo);//doblock함수 사용해 블록의 특징에 따른 작업 수행
        if(todo == 10) //repeat일때
        {
            InBlock = GameObject.Find(NowBlock.childblock.name).GetComponent<BlockTouchEvent>();
            todo = (int)InBlock.feature;
            for(int i = 0; i < 2; i++)
            {
                DoBlock(todo);
            }
        }//repeat끝
        else if(todo == 11)//ifyellow일때
        {
            Debug.Log(NowColor);
            if(NowColor == 2)
            {
                InBlock = GameObject.Find(NowBlock.childblock.name).GetComponent<BlockTouchEvent>();
                todo = (int)InBlock.feature;
                DoBlock(todo);
            }           
        }//ifyellow 끝
        
        NowBlock = GameObject.Find(NowBlock.nextblock.name).GetComponent<BlockTouchEvent>();//넘어가는 코드
        Debug.Log(NowBlock);
        if (NowBlock.name == "FinishBlock")
        {
            Arrowgo = false;
        }
        
        Invoke("MoveDown", MoveTime);
        MoveTime += 1f;
        
    }

    public void DoBlock(int feature)
    {
        if(feature == 0)
        {
            Debug.Log("Let's start!");
        }
        else if(feature == 1)
        {
            Debug.Log("Change Red!");
            StackIn(NowColor);
            NowColor = 1;
            Invoke("ChangeRed", MoveTime);
            MoveTime += 1f;
            //빨간색 스택처리.
        }
        else if (feature == 2)
        {
            Debug.Log("Change Yellow!");
            StackIn(NowColor);
            NowColor = 2;
            Invoke("ChangeYellow", MoveTime);
            MoveTime += 1f;
            //노랑색 스택처리.
        }
        else if (feature == 3)
        {
            Debug.Log("Change Blue!");
            StackIn(NowColor);
            NowColor = 3;
            Invoke("ChangeBlue", MoveTime);
            MoveTime += 1f;
            //파란색 스택처리.
        }
        else if(feature == 6)
        {
            Debug.Log("Color Back!");
            NowColor = StackOut();
            if (NowColor == 0)
            {
                Invoke("ChangeWhite", MoveTime);                
            }
            else if (NowColor == 1)
            {
                Invoke("ChangeRed", MoveTime);
            }
            else if (NowColor == 2)
            {
                Invoke("ChangeYellow", MoveTime);
            }
            else if(NowColor == 3)
            {
                Invoke("ChangeBlue", MoveTime);
            } 
            MoveTime += 1f;
        }
        else if(feature == 10)
        {
            Debug.Log("Repeat!");
            
        }
        else if(feature == 11)
        {
            Debug.Log("If Yellow?");
            
        }
        else if( feature == 50)
        {
            Debug.Log("Clear!");
            IsClear = true;
        }
        
    }
    public void MoveDown()
    {
        foreach (Transform child in transform)
        {
            child.Translate(Vector2.down);
        }
        Debug.Log("wait..");
    }
    void Update()
    {
        if (start)
        {
            while(Arrowgo)
            {
                MoveObjects();
            }
            if(IsClear)
            {
                ResultScript resultScript = GameObject.FindObjectOfType<ResultScript>();
                resultScript.result = 1;
                Debug.Log("result is 1 in arrowscript");
            }
            else
            {
                ResultScript resultScript = GameObject.FindObjectOfType<ResultScript>();
                resultScript.result = 2;
                Debug.Log("result is 2 in arrowscript");
            }
            Debug.Log("over?");
            start = false;
        }
    }

    public void Starting()
    {
        start = true;
    }

    void ChangeWhite()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        whitearrow.gameObject.SetActive(true); // 또는 false로 설정
        redarrow.gameObject.SetActive(false); // 또는 false로 설정
        yellowarrow.gameObject.SetActive(false); // 또는 false로 설정
        bluearrow.gameObject.SetActive(false); // 또는 false로 설정
    }

    void ChangeRed()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        whitearrow.gameObject.SetActive(false); // 또는 false로 설정
        redarrow.gameObject.SetActive(true); // 또는 false로 설정
        yellowarrow.gameObject.SetActive(false); // 또는 false로 설정
        bluearrow.gameObject.SetActive(false); // 또는 false로 설정
    }

    void ChangeYellow()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        whitearrow.gameObject.SetActive(false); // 또는 false로 설정
        redarrow.gameObject.SetActive(false); // 또는 false로 설정
        yellowarrow.gameObject.SetActive(true); // 또는 false로 설정
        bluearrow.gameObject.SetActive(false); // 또는 false로 설정
    }

    void ChangeBlue()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        whitearrow.gameObject.SetActive(false); // 또는 false로 설정
        redarrow.gameObject.SetActive(false); // 또는 false로 설정
        yellowarrow.gameObject.SetActive(false); // 또는 false로 설정
        bluearrow.gameObject.SetActive(true); // 또는 false로 설정
    }
    
    /// <summary>
    /// 스택 변수. 0 하얀색 1 빨간색 2 노란색 3 파란색
    /// </summary>
    /// <param name="value"></param>
    public void StackIn(int value)
    {
        ColorStack.Push(value);
        Debug.Log(value + "color in");
    }
    public int StackOut()
    {
        int a = 0;
        if(ColorStack.Count > 0)
        {
            a = ColorStack.Pop();
            Debug.Log(a + "color out");
        }
        return a;
    }
}
