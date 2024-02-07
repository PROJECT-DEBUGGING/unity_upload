using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{
    public float delay = 0f;   // 트리거 딜레이 (옵션)
    public string dialogueNode;
    private void Start()
    {
        // 게임 오브젝트가 활성화되면 자동으로 대화 시작
        StartCoroutine(TriggerDialogueAfterDelay());
    }

    IEnumerator TriggerDialogueAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        TriggerDialogue();
    }

    // 대화를 트리거하는 함수

    public void TriggerDialogue()
    {
        // DialogueRunner 객체 가져오기
        DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();

        if (dialogueRunner != null)
        {
            // 대화 실행
            dialogueRunner.StartDialogue(dialogueNode);
        }
        else
        {
            Debug.LogError("DialogueRunner not found in the scene.");
        }
    }
}