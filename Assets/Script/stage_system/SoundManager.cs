using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn.Unity;
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
    public string name; // SE에는 Button이 필요
    public SESound(string name, AudioClip clip, float volume, bool isLoop)
    {
        this.name = name;
        this.clip = clip;
        this.volume = volume;
        this.isLoop = isLoop;
    }
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public BgmSound[] bgmInfo = null;
    public List<AudioSource> sePlayers = new List<AudioSource>();
    public List<SESound> seInfo = new List<SESound>();

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
        foreach (SESound sound in seInfo)
        {
            sePlayers.Add(gameObject.AddComponent<AudioSource>());
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
            // 일치하는 씬 BGM을 찾지 못하고 현재 BGM이 재생 중인 경우, 멈춤
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
    public void StopSE()
    {
        foreach (AudioSource sePlayer in sePlayers)
        {
            if (sePlayer.isPlaying)
            {
                sePlayer.Stop();
            }
        }
    }

    public void PlaySE(string seName)
    {
        SESound se = seInfo.Find(x => x.name == seName);
        if (se != null)
        {
           

            int index = seInfo.IndexOf(se);
            if (index < sePlayers.Count)
            {
                sePlayers[index].clip = se.clip;
                sePlayers[index].volume = se.volume;
                sePlayers[index].loop = se.isLoop;
                sePlayers[index].Play();

            }
            else
            {
                Debug.LogError("sePlayers list is not properly initialized. Ensure that the sizes of seInfo and sePlayers match.");
            }
        }
        else
        {
            Debug.LogError("SE not found with name: " + seName);
        }
    }

    [YarnCommand("StopBGM")]
    public void Stopbmg()
    {
        StopBGM();
    }

    [YarnCommand("StopSound")]
    public void StopSound()
    {
        StopSE();
    }

    [YarnCommand("PlaySound")]
    public void PlaySound()
    {
        PlaySE("error_ef");
    }
}