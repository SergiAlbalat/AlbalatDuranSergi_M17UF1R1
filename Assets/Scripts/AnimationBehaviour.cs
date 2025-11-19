using UnityEngine;
[RequireComponent (typeof(Animator))]

public class AnimationBehaviour : MonoBehaviour
{
    [SerializeField] private bool fall;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _characterRight = false;
    private bool _characterLeft = true;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void RunAnimation(Vector2 direction)
    {
        if (direction.x > 0)
            _spriteRenderer.flipX = _characterRight;
        else if(direction.x < 0)
            _spriteRenderer.flipX = _characterLeft;
        _animator.SetFloat("Velocity", Mathf.Abs(direction.x));
    }
    public void FallAnimation(bool ground)
    {
        if(fall)
            _animator.SetBool("Ground", ground);
    }
    public void FlipSpriteX()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        _characterRight = !_characterRight;
        _characterLeft = !_characterLeft;
    }
}
