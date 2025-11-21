using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogue;
    private void Awake()
    {
        dialoguePanel.SetActive(false);
    }
    public void WriteDialogue(string message)
    {
        dialoguePanel.SetActive(true);
        dialogue.text = message;
    }
    public void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
