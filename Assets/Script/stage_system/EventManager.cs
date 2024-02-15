using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EventManager : MonoBehaviour
{
    public AudioSource defaultAudioSource; // 기본적으로 사용할 음향
    public List<CharacterSoundEntry> characterSounds = new List<CharacterSoundEntry>(); // 각 캐릭터에 대한 음향 목록

    // Yarn Spinner의 DialogueRunner 컴포넌트
    private DialogueRunner dialogueRunner;

    [System.Serializable]
    public class CharacterSoundEntry
    {
        public string characterName; // 캐릭터 이름
        public AudioClip characterSound; // 해당 캐릭터의 음향
    }

   private void SetCharacterName(string[] parameters, System.Action onComplete)
    {
        if (parameters.Length >= 1)
        {
            string characterName = parameters[0];

            // 현재 대화의 캐릭터 이름에 해당하는 음향을 찾아 재생
            PlayCharacterSoundForCurrentDialogue(characterName);
        }

        // onComplete을 호출하여 Yarn Spinner에게 해당 명령이 완료되었음을 알립니다.
        onComplete();
    }

    private void PlayCharacterSoundForCurrentDialogue(string characterName)
    {
        // 현재 대화의 캐릭터 이름에 해당하는 음향을 찾아 재생
        CharacterSoundEntry characterSoundEntry = GetCharacterSoundEntry(characterName);

        if (characterSoundEntry != null)
        {
            PlayCharacterSound(characterSoundEntry.characterSound);
        }
    
    }
    private CharacterSoundEntry GetCharacterSoundEntry(string characterName)
    {
        return characterSounds.Find(entry => entry.characterName == characterName);
    }

    private void PlayCharacterSound(AudioClip sound)
    {
        if (sound != null)
        {
            defaultAudioSource.PlayOneShot(sound);
        }
    }

}