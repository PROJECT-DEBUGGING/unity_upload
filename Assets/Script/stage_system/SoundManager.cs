using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Sound
{
    public AudioClip clip;
    public float volume;
    public bool isLoop;
}

[System.Serializable]
public class BgmSound : Sound
{
    public string sceneName; // BGM에는 sceneName이 필요
    public BgmSound(string sceneName, AudioClip clip, float volume, bool isLoop)
    {
        this.sceneName = sceneName;
        this.clip = clip;
        this.volume = volume;
        this.isLoop = isLoop;
    }
}

[System.Serializable]
public class SESound : Sound
{
    public Button button; // SE에는 Button이 필요
    public SESound(Button button, AudioClip clip, float volume, bool isLoop)
    {
        this.button = button;
        this.clip = clip;
        this.volume = volume;
        this.isLoop = isLoop;
    }
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public BgmSound[] bgmInfo = null;
    public SESound[] seInfo = null;
    private List<AudioSource> sePlayers;

    private AudioSource bgmPlayer;
    private int currentBGMIndex;

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

        bgmPlayer = gameObject.AddComponent<AudioSource>();

        PlayBGM(SceneManager.GetActiveScene().name);
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로딩이 완료될 때마다 이벤트 핸들러 호출
        sePlayers = new List<AudioSource>();
        for (int i = 0; i < seInfo.Length; i++)
        {
            sePlayers.Add(gameObject.AddComponent<AudioSource>());
            // 버튼 클릭 이벤트에 대한 리스너 등록
            seInfo[i].button.onClick.AddListener(() => PlaySE(seInfo[i].button));
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGM(scene.name); // 새로운 씬이 로딩될 때마다 BGM을 재생
    }



    private void PlayBGM(string p_name)
    {
        bool foundBGM = false;

        for (int i = 0; i < bgmInfo.Length; i++)
        {
            if (p_name == bgmInfo[i].sceneName)
            {
                if (bgmPlayer.isPlaying && bgmPlayer.clip == bgmInfo[i].clip)
                {
                    // 이미 현재 BGM이 재생 중이면 아무것도 하지 않음
                    foundBGM = true;
                    break;
                }

                // BGM 변경
                bgmPlayer.Stop();
                bgmPlayer.clip = bgmInfo[i].clip;
                bgmPlayer.volume = bgmInfo[i].volume;
                bgmPlayer.loop = bgmInfo[i].isLoop;
                bgmPlayer.Play();

                currentBGMIndex = i;
                Debug.Log(bgmInfo[i].sceneName);

                foundBGM = true;
                break;
            }
        }

        if (!foundBGM && bgmPlayer.isPlaying)
        {
            // 일치하는 씬 BGM을 찾지 못하고 현재 BGM이 재생 중인 경우, 멈춥니다.
            bgmPlayer.Stop();
        }
    }

    public void StopBGM()
    {
        if (bgmPlayer.isPlaying)
        {
            bgmPlayer.Stop();
        }
    }

    public void PlaySE(Button button)
    {
        // buttonName에 해당하는 SE를 찾아서 재생
        for (int i = 0; i < seInfo.Length; i++)
        {
            if (button == seInfo[i].button)
            {
                sePlayers[i].clip = seInfo[i].clip;
                sePlayers[i].volume = seInfo[i].volume;
                sePlayers[i].loop = seInfo[i].isLoop;
                sePlayers[i].Play();
                break;
            }
        }
    }
}