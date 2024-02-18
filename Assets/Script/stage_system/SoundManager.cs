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
    public string sceneName; // BGM���� sceneName�� �ʿ�
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
    public string name; // SE���� Button�� �ʿ�
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
        SceneManager.sceneLoaded += OnSceneLoaded; // �� �ε��� �Ϸ�� ������ �̺�Ʈ �ڵ鷯 ȣ��
        foreach (SESound sound in seInfo)
        {
            sePlayers.Add(gameObject.AddComponent<AudioSource>());
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGM(scene.name); // ���ο� ���� �ε��� ������ BGM�� ���
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
                    // �̹� ���� BGM�� ��� ���̸� �ƹ��͵� ���� ����
                    foundBGM = true;
                    break;
                }

                // BGM ����
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
            // ��ġ�ϴ� �� BGM�� ã�� ���ϰ� ���� BGM�� ��� ���� ���, ����
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