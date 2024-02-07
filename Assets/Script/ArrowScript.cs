using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArrowScript : MonoBehaviour
{
    public float pauseTime = 1f;//ȭ��ǥ�� ������ ������ �ð�. 1��
    public Boolean start = false;//����� ��ư ���� �� ���̵�. ���� ����
    public Boolean Arrowgo = true;//while�� ����� ��
    public Boolean IsClear = false;
    public BlockTouchEvent NowBlock;//���� �� �ڽ� ���� ���
    public BlockTouchEvent InBlock;//���� ����Ʈ, ���� ����� �� ������ ��ɾ� ����
    public GameObject ArrowAll;

    private RectTransform Arrowrect;
    public RectTransform Blockrect;

    public float MoveTime = 2f;
    private Queue<RectTransform> BlockQueue = new Queue<RectTransform>();//��ġ ������ ť
    private Stack<int> ColorStack; // ����
    private int NowColor;
    void Start()
    {
        ColorStack = new Stack<int>();
        NowColor = 0;
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        Arrowrect = GetComponent<RectTransform>();

        NowBlock = GameObject.Find("Start").GetComponent<BlockTouchEvent>();
        Blockrect = NowBlock.GetComponent<RectTransform>();

        ArrowAll = GameObject.Find(gameObject.name);
        Debug.Log(ArrowAll.gameObject.name);
        // ã�� ���� ������Ʈ�� Ȱ��ȭ ���� ����
        whitearrow.gameObject.SetActive(true); // �Ǵ� false�� ����
        redarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        yellowarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        bluearrow.gameObject.SetActive(false); // �Ǵ� false�� ����       
    }
    /// <summary>
    /// start moving arrow
    /// </summary>
    public void MoveObjects()
    {
        int todo = (int) NowBlock.feature;//enum���� �־��� ����� Ư¡ int�� ��ȯ
        Debug.Log(todo);
        DoBlock(todo);//doblock�Լ� ����� ����� Ư¡�� ���� �۾� ����
        if(todo == 10) //repeat�϶�
        {
            Debug.Log(NowBlock.RepeatCount);
            InBlock = GameObject.Find(NowBlock.childblock.name).GetComponent<BlockTouchEvent>();
            todo = (int)InBlock.feature;
            for(int i = 0; i < NowBlock.RepeatCount; i++)
            {
                DoBlock(todo);
            }
        }//repeat��
        else if(todo == 11)//ifyellow�϶�
        {
            Debug.Log(NowColor);
            if(NowColor == 2)
            {
                InBlock = GameObject.Find(NowBlock.childblock.name).GetComponent<BlockTouchEvent>();
                todo = (int)InBlock.feature;
                DoBlock(todo);
            }           
        }
        else if(todo == 12)//ifwhite�϶�
        {
            Debug.Log(NowColor);
            if (NowColor == 0)
            {
                InBlock = GameObject.Find(NowBlock.childblock.name).GetComponent<BlockTouchEvent>();
                todo = (int)InBlock.feature;
                DoBlock(todo);
            }
        }
        else if (todo == 13)//ifred�϶�
        {
            Debug.Log(NowColor);
            if (NowColor == 1)
            {
                InBlock = GameObject.Find(NowBlock.childblock.name).GetComponent<BlockTouchEvent>();
                todo = (int)InBlock.feature;
                DoBlock(todo);
            }
        }
        else if (todo == 14)//ifBlue�϶�
        {
            Debug.Log(NowColor);
            if (NowColor == 3)
            {
                InBlock = GameObject.Find(NowBlock.childblock.name).GetComponent<BlockTouchEvent>();
                todo = (int)InBlock.feature;
                DoBlock(todo);
            }
        }

        NowBlock = GameObject.Find(NowBlock.nextblock.name).GetComponent<BlockTouchEvent>();//�Ѿ�� �ڵ�
        Debug.Log(NowBlock);
        Blockrect = NowBlock.GetComponent<RectTransform>();
        BlockQueue.Enqueue(Blockrect);

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
            //������ ����ó��.
        }
        else if (feature == 2)
        {
            Debug.Log("Change Yellow!");
            StackIn(NowColor);
            NowColor = 2;
            Invoke("ChangeYellow", MoveTime);
            MoveTime += 1f;
            //����� ����ó��.
        }
        else if (feature == 3)
        {
            Debug.Log("Change Blue!");
            StackIn(NowColor);
            NowColor = 3;
            Invoke("ChangeBlue", MoveTime);
            MoveTime += 1f;
            //�Ķ��� ����ó��.
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
        else if(feature == 7)//remove
        {
            Debug.Log("Color remove!");
            NowColor = StackAllOut();
            Invoke("ChangeWhite", MoveTime);
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
        else if (feature == 12)
        {
            Debug.Log("If white?");

        }
        else if (feature == 13)
        {
            Debug.Log("If red?");

        }
        else if( feature == 50)
        {
            Debug.Log("Clear!");
            IsClear = true;
        }       
    }
    public void MoveDown()
    {
        RectTransform rectTransform = BlockQueue.Dequeue();
        Vector2 NowBlockPosition = rectTransform.position;
        Vector2 ArrowVector = new Vector2(NowBlockPosition.x - 2.5f, NowBlockPosition.y);
        Arrowrect.position = ArrowVector;
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
                resultScript.result = 1;//1�� Ŭ����
                Debug.Log("result is 1 in arrowscript");
                
            }
            else
            {
                ResultScript resultScript = GameObject.FindObjectOfType<ResultScript>();
                resultScript.result = 2;//2�� ����
                
                Debug.Log("result is 2 in arrowscript");
                NowBlock = GameObject.Find("Start").GetComponent<BlockTouchEvent>();
                Blockrect = NowBlock.GetComponent<RectTransform>();
                BlockQueue.Enqueue(Blockrect);
                Invoke("MoveDown", MoveTime);
                NowColor = StackAllOut();
                Invoke("ChangeWhite", MoveTime);
                
                MoveTime += 1f;
            }
            Arrowgo = true;
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

        whitearrow.gameObject.SetActive(true); // �Ǵ� false�� ����
        redarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        yellowarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        bluearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
    }

    void ChangeRed()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        whitearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        redarrow.gameObject.SetActive(true); // �Ǵ� false�� ����
        yellowarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        bluearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
    }

    void ChangeYellow()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        whitearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        redarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        yellowarrow.gameObject.SetActive(true); // �Ǵ� false�� ����
        bluearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
    }

    void ChangeBlue()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        whitearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        redarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        yellowarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        bluearrow.gameObject.SetActive(true); // �Ǵ� false�� ����
    }
    
    /// <summary>
    /// ���� ����. 0 �Ͼ�� 1 ������ 2 ����� 3 �Ķ���
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
    public int StackAllOut()
    {
        while(ColorStack.Count > 0)
        {
            ColorStack.Pop();
        }
        return 0;
    }
}
