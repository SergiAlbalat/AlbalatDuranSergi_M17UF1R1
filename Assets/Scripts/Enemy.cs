using Unity.Cinemachine;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Rigidbody2D _rb;
    private Transform _playerPosition;
    private bool _chasing = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(_chasing && _playerPosition != null)
        {
            Vector2 direction = _playerPosition.position - transform.position;
            _rb.linearVelocity = new Vector2(direction.x * speed, _rb.linearVelocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerPosition = collision.transform;
            _chasing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _chasing = false;
        }
    }
}
