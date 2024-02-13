using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RepeatNumber : MonoBehaviour
{
    public GameObject RepeatObject;
    public BlockTouchEvent BTE;
    public TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        BTE = RepeatObject.GetComponent<BlockTouchEvent>();
    }
    void Update()
    {
        textMesh.text = BTE.RepeatCount.ToString();
    }
}
