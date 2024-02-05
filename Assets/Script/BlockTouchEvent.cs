using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockTouchEvent : MonoBehaviour
{
    public MainSystemScript mainsystemscript;
    public GameObject nextblock;
    public GameObject childblock;
    public enum BlockFeature
    {
        Start = 0, ChangeRed = 1, ChangeYellow = 2, ChangeBlue = 3, End = 50, Back = 6, Remove = 7, Repeat = 10, 
        IfYellow = 11, IfWhite = 12, IfRed = 13, IfBlue = 14
            , finish = 99
    }
    public enum Moveable
    {
        able, unable
    }
    public Moveable moveable;
    public BlockFeature feature;
    public Vector2 NowLocation;
    public int RepeatCount;
    // Update is called once per frame
    private void Start()
    {
        GameObject mainSystemObject = GameObject.Find("Main_System");//���� �ý��� ��ɾ� ��������
        mainsystemscript = mainSystemObject.GetComponent<MainSystemScript>();//��ũ��Ʈ ��������
        NowLocation = transform.position; //�� ��ġ
        
    }
    void Update()
    {
        transform.position = NowLocation;
    }
    public void SelectButton()
    {
        Debug.Log(gameObject.name);
        if(moveable == Moveable.unable)
        {
            Debug.Log("������ �� �����ϴ�");
        }
        else if (moveable == Moveable.able)
        {
            if (mainsystemscript.Choise1 != null)
            {
                Debug.Log("Choise1 is not null");
                if(mainsystemscript.Choise2 == null)
                {
                    Debug.Log("Choise2 is null");
                    // �ڱ� �ڽ��� GameObject�� Choise2�� �Ҵ�
                    mainsystemscript.Choise2 = gameObject;
                }
            }
            else
            {
                Debug.Log("Choise1 is null");
                // �ڱ� �ڽ��� GameObject�� Choise1�� �Ҵ�
                mainsystemscript.Choise1 = gameObject;
            }
        }
        
    }

}
