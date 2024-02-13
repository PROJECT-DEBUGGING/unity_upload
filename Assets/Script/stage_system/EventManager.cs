using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public AudioClip clickSound; // Ŭ�� �� ����� ����
    private AudioSource audioSource;

    private void Awake()
    {
        // ����� �ҽ� ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();
    }

    // ���콺 Ŭ�� �� ȣ���� �Լ�
    public void OnClick()
    {
        // Ŭ�� ���� ���
        PlayClickSound();
    }

    // Ŭ�� ���� ��� �Լ�
    private void PlayClickSound()
    {
        // ������ �����Ǿ� ������ ���
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }





}
