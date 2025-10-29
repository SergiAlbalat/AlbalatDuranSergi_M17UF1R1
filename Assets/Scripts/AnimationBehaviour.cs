using UnityEngine;
[RequireComponent (typeof(Animator))]

public class AnimationBehaviour : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void RunAnimation(Vector2 direction)
    {
        if (direction.x > 0)
            _spriteRenderer.flipX = false;
        else if(direction.x < 0)
            _spriteRenderer.flipX = true;
        _animator.SetFloat("Velocity", direction.magnitude);
    }
    public void FallAnimation(Rigidbody2D direction)
    {
        if(direction.gravityScale > 0)
            _spriteRenderer.flipY = false;
        else if(direction.gravityScale < 0)
            _spriteRenderer.flipY = true;
        _animator.SetFloat("FallSpeed", direction.linearVelocityY);
    }
}
