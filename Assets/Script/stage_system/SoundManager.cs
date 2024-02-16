using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Sound
{
    public string sceneName;
    public AudioClip clip;
    public float volume;
    public bool isLoop;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; 
    public AudioSource bgmPlayer = null;
    public Sound[] bgmInfo = null; 

    private int currentBGMIndex;
    private float defaultVolume = 1.0f; // 추가: defaultVolume 정의

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        PlayBGM(SceneManager.GetActiveScene().name);
        
    }

    private void PlayBGM(string p_name)
    {
        for (int i = 0; i < bgmInfo.Length; i++)
        {
            if (p_name == bgmInfo[i].sceneName)
            {
                // 클립이 같은 경우 그대로 두는 거 추가
                // if문 넣은 이유 : PlayBGM이 계속 호출되는 것만 주의하면 됨.
                bgmPlayer.clip = bgmInfo[i].clip;
                bgmPlayer.volume = bgmInfo[i].volume;
                bgmPlayer.loop = true;
                bgmPlayer.Play(); // 이미 실행 중인 것을 계속 플레이 하는 경우 있으므로 그러면 if문 넣기
                currentBGMIndex = i;

                Debug.Log(bgmInfo[i].sceneName); // 이 부분을 return 전에 이동
                return; // 이 부분이 if문 밖으로 이동
            }
        }
    }

    public void StopBGM()
    {
        if (bgmPlayer.isPlaying)
        {
            bgmPlayer.Stop();
        }
    }

    public void PlayAudio(string p_name, string p_type, float volume)
    {
        if (p_type == "BGM") PlayBGM(p_name);
       
    }
    // 오디오 이름 , 클립 넣는 함수가 ㅇ없음 play bgm이 실행이 안됨. 
}