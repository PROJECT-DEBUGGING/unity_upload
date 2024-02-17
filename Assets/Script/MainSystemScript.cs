using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystemScript : MonoBehaviour
{
    public BlockTouchEvent block1;
    public BlockTouchEvent block2;
    public Vector2 Loca1;
    public Vector2 Loca2;
    public GameObject Choise1;
    public GameObject Choise2;
    // Start is called before the first frame update
    void Start()
    {
        Choise1 = null;
        Choise2 = null;
    }

    // Update is called once per frame
    void Update()
    {
        ResultScript resultScript = GameObject.FindObjectOfType<ResultScript>();
        if (resultScript.CantDebug)
        {
            if (Choise1 != null && Choise2 != null)
            {
                Debug.Log("choise end" + Choise1.name + Choise2.name);
                if (Choise1 != Choise2)
                {
                    GameObject tmp;
                    Vector2 locatmp;
                    GameObject BlockObject1 = GameObject.Find(Choise1.name);//�ٲ���1
                    GameObject BlockObject2 = GameObject.Find(Choise2.name);//�ٲ���2
                    block1 = BlockObject1.GetComponent<BlockTouchEvent>();
                    block2 = BlockObject2.GetComponent<BlockTouchEvent>();//����
                    BlockTouchEvent[] AllBlock = FindObjectsOfType<BlockTouchEvent>();//next�� �ٲ����� ��ã�� - �ٲ����� next�� ���
                    foreach (BlockTouchEvent EachBlock in AllBlock)//ã�´ٸ� �ݴ�Ǵ� ������� next ��ȯ
                    {
                        if (EachBlock.nextblock == Choise1)
                        {
                            EachBlock.nextblock = Choise2;
                        }
                        else if (EachBlock.nextblock == Choise2)
                        {
                            EachBlock.nextblock = Choise1;
                        }
                    }
                    tmp = block1.nextblock;
                    block1.nextblock = block2.nextblock;
                    block2.nextblock = tmp;//�ٲ��󳢸� ��ȯ - �ٲ���
                    locatmp = block1.NowLocation;
                    block1.NowLocation = block2.NowLocation;
                    block2.NowLocation = locatmp;//����� ��ġ ��ȯ
                    Debug.Log("changed!");
                }
                else
                {
                    Debug.Log("same. try again");
                }
                Choise1 = null;
                Choise2 = null;
            }
        }
        
    }
}
