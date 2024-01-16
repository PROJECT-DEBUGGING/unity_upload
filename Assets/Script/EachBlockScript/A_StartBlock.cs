using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_StartBlock : MonoBehaviour
{
    // Start is called before the first frame update
    ElementsOfBlock StartBlock;
    void Start()
    {
        StartBlock = new ElementsOfBlock("start",1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
