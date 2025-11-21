using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character, InputSystem_Actions.IPlayerActions, IKillable
{
    private InputSystem_Actions _actions;
    private Vector2 _movement;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dieSound;

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
        if (context.performed)
        {
            _mb.ChangeGravity();
           
        }
    }
    public void Kill()
    {
        transform.position = _spawnPoint.position;
        if(audioSource != null)
            audioSource.PlayOneShot(dieSound);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
            Kill();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("Enemy"))
            Kill();
    }
    public void StopPlayer()
    {
        _actions.Disable();
    }
    public void ResumePlayer()
    {
        _actions.Enable();
    }
}