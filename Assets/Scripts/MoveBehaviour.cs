using UnityEngine;
public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private AnimationBehaviour _animation;
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
        _rb.gravityScale = -_rb.gravityScale;
    }
}