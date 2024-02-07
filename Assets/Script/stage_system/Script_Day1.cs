using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueTrigger : MonoBehaviour
{
    public float delay = 0f;   // Ʈ���� ������ (�ɼ�)
    public string dialogueNode;
    private void Start()
    {
        // ���� ������Ʈ�� Ȱ��ȭ�Ǹ� �ڵ����� ��ȭ ����
        StartCoroutine(TriggerDialogueAfterDelay());
    }

    IEnumerator TriggerDialogueAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        TriggerDialogue();
    }

    // ��ȭ�� Ʈ�����ϴ� �Լ�

    public void TriggerDialogue()
    {
        // DialogueRunner ��ü ��������
        DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();

        if (dialogueRunner != null)
        {
            // ��ȭ ����
            dialogueRunner.StartDialogue(dialogueNode);
        }
        else
        {
            Debug.LogError("DialogueRunner not found in the scene.");
        }
    }
}