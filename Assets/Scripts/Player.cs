using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions _actions;
    private Vector2 _movement;
    private void Awake()
    {
        base.Awake();
        _actions = new InputSystem_Actions();
        _actions.Player.AddCallbacks(this);
    }
    private void OnEnable()
    {
        _actions.Enable();
    }
    private void OnDisable()
    {
        _actions.Disable();
    }
    private void FixedUpdate()
    {
        _mb.Move(_movement);
        Debug.DrawRay(transform.position, -transform.up * 0.65f, Color.red);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        _mb.ChangeGravity();  
    }
}