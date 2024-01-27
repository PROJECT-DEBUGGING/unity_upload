using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatArrow : MonoBehaviour
{
    public GameObject ParentsRepeat;
    public BlockTouchEvent BTE;

    public enum ArrowWay
    {
        up, down
    }
    public ArrowWay way;

    void Start()
    {
        BTE = ParentsRepeat.GetComponent<BlockTouchEvent>();
    }
    public void ClickEvent()
    {
        if(way == ArrowWay.up)
        {
            if (BTE.RepeatCount < 5)
            {
                BTE.RepeatCount++;
            }
        }
        else if(way == ArrowWay.down)
        {
            if (BTE.RepeatCount > 1)
            {
                BTE.RepeatCount--;
            }
        }
    }
    
}
