using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private AnimationBehaviour _animation;
    private RaycastHit2D _ground;
    private bool _gravity = true;
    public LayerMask groundMask;
    [SerializeField] private float speed = 3f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animation = GetComponent<AnimationBehaviour>();
    }
    private void Update()
    {
        if(_animation != null)
            _animation.FallAnimation(_ground.collider);
    }
    private void FixedUpdate()
    {
        _ground = Physics2D.Raycast(_rb.position, -transform.up, 0.65f, groundMask);
    }
    public void Move(Vector2 direction)
    {
        _rb.linearVelocity = new Vector2 (direction.normalized.x * speed, _rb.linearVelocity.y);
        if(_animation != null) 
            _animation.RunAnimation(new Vector2(direction.normalized.x, _rb.linearVelocity.y));
    }
    public void Fly(Vector2 direction)
    {
        _rb.linearVelocity = direction * speed;
    }
    public void ChangeGravity()
    {
        if (_ground.collider != null)
        {
            _rb.gravityScale = -_rb.gravityScale;
            float rotation = _gravity ? 180f : 0f;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation);
            _gravity = !_gravity;
            _animation.FlipSpriteX();
        }
    }
}