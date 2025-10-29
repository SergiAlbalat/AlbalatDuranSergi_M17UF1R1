using Unity.VisualScripting;
using UnityEngine;
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private AnimationBehaviour _animation;
    private bool _gravity = true;
    private RaycastHit2D _ground;
    [SerializeField] private float speed = 3f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animation = GetComponent<AnimationBehaviour>();
    }
    public void Move(Vector2 direction)
    {
        _rb.linearVelocity = new Vector2 (direction.normalized.x * speed, _rb.linearVelocity.y);
        _animation.RunAnimation(direction);
    }
    public void ChangeGravity()
    {
        if (_gravity)
            _ground = Physics2D.Raycast(_rb.position, Vector2.down, 1f);
        else
            _ground = Physics2D.Raycast(_rb.position, Vector2.up, 1f);
        Debug.DrawRay(_rb.position, new Vector2(_rb.position.x, _rb.position.y + 1f));
        if (_ground.collider.gameObject.layer == 6)
        {
            _gravity = !_gravity;
            _rb.gravityScale = -_rb.gravityScale;
            _animation.FallAnimation(_rb);
        }
    }
}