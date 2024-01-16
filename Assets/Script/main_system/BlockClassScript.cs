using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsOfBlock
{
    public string BlockName;
    public int BlockLocation;
    public ElementsOfBlock(string name, int loca)
    {
        BlockName = name;
        BlockLocation = loca;
    }

    public void DisplayPlayerInfo()
    {
        Debug.Log($"Player: ");
    }
}
