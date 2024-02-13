using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public AudioClip clickSound; // 클릭 시 재생할 음향
    private AudioSource audioSource;

    private void Awake()
    {
        // 오디오 소스 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();
    }

    // 마우스 클릭 시 호출할 함수
    public void OnClick()
    {
        // 클릭 사운드 재생
        PlayClickSound();
    }

    // 클릭 사운드 재생 함수
    private void PlayClickSound()
    {
        // 음향이 설정되어 있으면 재생
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }





}
