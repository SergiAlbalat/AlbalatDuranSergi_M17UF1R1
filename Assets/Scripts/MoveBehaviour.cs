using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 direction)
    {
        _rb.linearVelocity = direction.normalized;
    }
}
