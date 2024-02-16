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
    private float defaultVolume = 1.0f;

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
        SceneManager.sceneLoaded += OnSceneLoaded; // �� �ε��� �Ϸ�� ������ �̺�Ʈ �ڵ鷯 ȣ��
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
}