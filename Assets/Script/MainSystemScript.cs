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
                    GameObject BlockObject1 = GameObject.Find(Choise1.name);//바뀔대상1
                    GameObject BlockObject2 = GameObject.Find(Choise2.name);//바뀔대상2
                    block1 = BlockObject1.GetComponent<BlockTouchEvent>();
                    block2 = BlockObject2.GetComponent<BlockTouchEvent>();//지정
                    BlockTouchEvent[] AllBlock = FindObjectsOfType<BlockTouchEvent>();//next가 바뀔대상인 블럭찾기 - 바뀔대상이 next인 대상
                    foreach (BlockTouchEvent EachBlock in AllBlock)//찾는다면 반대되는 대상으로 next 변환
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
                    block2.nextblock = tmp;//바뀔대상끼리 변환 - 바뀔대상
                    locatmp = block1.NowLocation;
                    block1.NowLocation = block2.NowLocation;
                    block2.NowLocation = locatmp;//대상의 위치 변환
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
