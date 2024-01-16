using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTouchEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);//physics��ɾ� ���, Ŭ�� ��ȣ�ۿ� ������ ������Ʈ�� ������Ʈ �־����.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Moveable_Button"))
                {
                    Debug.Log("�̵����ɺ��");
                    // �÷��̾ ���� �߰� ������ ����
                }
                else if (hit.collider.CompareTag("Fixed_Button"))
                {
                    Debug.Log("�̵��Ұ��ɺ��");
                    // ���� ���� �߰� ������ ����
                }

            }
        }
    }
}
