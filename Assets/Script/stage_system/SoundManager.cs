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
    private float defaultVolume = 1.0f; // �߰�: defaultVolume ����

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
                // Ŭ���� ���� ��� �״�� �δ� �� �߰�
                // if�� ���� ���� : PlayBGM�� ��� ȣ��Ǵ� �͸� �����ϸ� ��.
                bgmPlayer.clip = bgmInfo[i].clip;
                bgmPlayer.volume = bgmInfo[i].volume;
                bgmPlayer.loop = true;
                bgmPlayer.Play(); // �̹� ���� ���� ���� ��� �÷��� �ϴ� ��� �����Ƿ� �׷��� if�� �ֱ�
                currentBGMIndex = i;

                Debug.Log(bgmInfo[i].sceneName); // �� �κ��� return ���� �̵�
                return; // �� �κ��� if�� ������ �̵�
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
    // ����� �̸� , Ŭ�� �ִ� �Լ��� ������ play bgm�� ������ �ȵ�. 
}