using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTouchEvent : MonoBehaviour//DebugTouchEvent�κ��� ��ũ��Ʈ �̸��� ���ƾ���
{
    void Start()
    {
        Debug.Log("����");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);//physics��ɾ� ���, Ŭ�� ��ȣ�ۿ� ������ ������Ʈ�� ������Ʈ �־����.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}