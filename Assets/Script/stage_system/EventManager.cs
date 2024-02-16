using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EventManager : MonoBehaviour
{
    public AudioSource defaultAudioSource; // �⺻������ ����� ����
    public List<CharacterSoundEntry> characterSounds = new List<CharacterSoundEntry>(); // �� ĳ���Ϳ� ���� ���� ���

    // Yarn Spinner�� DialogueRunner ������Ʈ
    private DialogueRunner dialogueRunner;

    [System.Serializable]
    public class CharacterSoundEntry
    {
        public string characterName; // ĳ���� �̸�
        public AudioClip characterSound; // �ش� ĳ������ ����
    }

   private void SetCharacterName(string[] parameters, System.Action onComplete)
    {
        if (parameters.Length >= 1)
        {
            string characterName = parameters[0];

            // ���� ��ȭ�� ĳ���� �̸��� �ش��ϴ� ������ ã�� ���
            PlayCharacterSoundForCurrentDialogue(characterName);
        }

        // onComplete�� ȣ���Ͽ� Yarn Spinner���� �ش� ����� �Ϸ�Ǿ����� �˸��ϴ�.
        onComplete();
    }

    private void PlayCharacterSoundForCurrentDialogue(string characterName)
    {
        // ���� ��ȭ�� ĳ���� �̸��� �ش��ϴ� ������ ã�� ���
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