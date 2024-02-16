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
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로딩이 완료될 때마다 이벤트 핸들러 호출
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
}