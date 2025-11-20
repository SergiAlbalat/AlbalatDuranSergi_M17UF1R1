using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueZone : MonoBehaviour, InputSystem_Actions.IUIActions
{
    [SerializeField] private Player player;
    [SerializeField] private DialogueBehaviour dB;
    [SerializeField] private List<string> dialogues;
    private int _currentDialogue = 0;
    private bool _inDialogue = false;
    private bool _nextDialogue = false;
    private bool _activated = false;
    private InputSystem_Actions _actions;
    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _actions.UI.SetCallbacks(this);
        _actions.Disable();
    }
    public void OnNextDialogue(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _nextDialogue = true;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _activated == false)
        {
            _inDialogue = true;
            _activated = true;
            _actions.Enable();
        }
    }
    private void Update()
    {
        if (_inDialogue)
        {
            player.StopPlayer();
            dB.WriteDialogue(dialogues[_currentDialogue]);
            if (_nextDialogue && _currentDialogue + 1 < dialogues.Count)
            {
                _currentDialogue++;
                dB.CloseDialogue();
                _nextDialogue = false;
            }
            else if(_nextDialogue && _currentDialogue + 1 == dialogues.Count)
            {
                dB.CloseDialogue();
                player.ResumePlayer();
                _inDialogue = false;
                _actions.Disable();
            }
        }
    }
}
