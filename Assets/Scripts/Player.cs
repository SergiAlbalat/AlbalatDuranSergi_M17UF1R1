using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character, InputSystem_Actions.IPlayerActions, IKillable
{
    private InputSystem_Actions _actions;
    private Vector2 _movement;
    [SerializeField] private Transform _spawnPoint;
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
    public void Kill()
    {
        transform.position = _spawnPoint.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
            Kill();
    }
}