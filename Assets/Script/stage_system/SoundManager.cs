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

        // bgmPlayer = gameObject.AddComponent<AudioSource>();     // 실행 시키면 사운드 매니저에 오디오 소스가 들어감. 내가 가지고 있는 오디오 소스를 비디오 플레이어에 가져다넣음
        // sePlayer = new List<AudioSource>();                     // 오디오 소스 많이 만들필요 없고 클립을 여러개 만드는게 나음, 스피커가 어려개가 나와야한다면 오디오 소스가 두 개
        // 오디오 소스 = 스피커
        
    }

    private void PlayBGM(string p_name)
    {
        for (int i = 0; i < bgmInfo.Length; i++)
        {
            if (p_name == bgmInfo[i].sceneName)
            {
                
                // 클립이 같은 경우 그대로 두는거 추가
                // if문 넣은 이유 : playbgm이 계속 호출되는 것만 주의하면 됨.
                bgmPlayer.clip = bgmInfo[i].clip;
                bgmPlayer.volume = bgmInfo[i].volume;
                bgmPlayer.loop = true; 
                bgmPlayer.Play();           // 이미 실행 중인 것을 계속 플레이 하는 경우 있으므로 그러면 if문 넣기
                currentBGMIndex = i;
                return;
                Debug.Log(bgmInfo[i].sceneName);
            }
        }
    }
    public void PlayAudio(string p_name, string p_type, float volume)
    {
        if (p_type == "BGM") PlayBGM(p_name);
       
    }
    // 오디오 이름 , 클립 넣는 함수가 ㅇ없음 play bgm이 실행이 안됨. 
}