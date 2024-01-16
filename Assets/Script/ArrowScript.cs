using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0.5f;
    public float pauseTime = 1f;
    void Start()
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");

        // ã�� ���� ������Ʈ�� Ȱ��ȭ ���� ����
        whitearrow.gameObject.SetActive(true); // �Ǵ� false�� ����
        redarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        yellowarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        bluearrow.gameObject.SetActive(false); // �Ǵ� false�� ����

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0)){ Change(0); }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) { Change(1); }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) { Change(2); }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) { Change(3); }

        //ȭ��ǥ �̵� ��ɾ�
        InvokeRepeating("MoveObjects", 0f, moveSpeed + pauseTime);
        
    }
    void MoveObjects()
    {
        foreach (Transform child in transform)
        {
            // ���� ��ġ���� ��ǥ ��ġ���� �̵�
            Vector2 currentPosition = child.position;
            Vector2 targetPosition = new Vector2(currentPosition.x, currentPosition.y - 0.5f);
            child.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    void Change(int color)//0 1 2 3 ������ ȭ��ǥ �� ����
    {
        Transform whitearrow = transform.Find("arrow_white_0");
        Transform redarrow = transform.Find("arrow_red_0");
        Transform yellowarrow = transform.Find("arrow_yellow_0");
        Transform bluearrow = transform.Find("arrow_blue_0");
        if (color == 0)//white
        {
            whitearrow.gameObject.SetActive(true); // �Ǵ� false�� ����
            redarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            yellowarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            bluearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        }
        else if (color == 1)//red
        {
            whitearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            redarrow.gameObject.SetActive(true); // �Ǵ� false�� ����
            yellowarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            bluearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        }
        else if (color == 2)//yellow
        {
            whitearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            redarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            yellowarrow.gameObject.SetActive(true); // �Ǵ� false�� ����
            bluearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
        }
        else if (color == 3)//blue
        {
            whitearrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            redarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            yellowarrow.gameObject.SetActive(false); // �Ǵ� false�� ����
            bluearrow.gameObject.SetActive(true); // �Ǵ� false�� ����
        }
    } 
}
