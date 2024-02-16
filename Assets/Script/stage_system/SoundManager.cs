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
    public Button button; // SE���� Button�� �ʿ�
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
        SceneManager.sceneLoaded += OnSceneLoaded; // �� �ε��� �Ϸ�� ������ �̺�Ʈ �ڵ鷯 ȣ��
        sePlayers = new List<AudioSource>();
        for (int i = 0; i < seInfo.Length; i++)
        {
            sePlayers.Add(gameObject.AddComponent<AudioSource>());
            // ��ư Ŭ�� �̺�Ʈ�� ���� ������ ���
            seInfo[i].button.onClick.AddListener(() => PlaySE(seInfo[i].button));
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
            // ��ġ�ϴ� �� BGM�� ã�� ���ϰ� ���� BGM�� ��� ���� ���, ����ϴ�.
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
        // buttonName�� �ش��ϴ� SE�� ã�Ƽ� ���
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