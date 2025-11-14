using Unity.Cinemachine;
using UnityEngine;

public class Enemy : Character
{
    private Transform _playerPosition;
    private bool _chasing = false;
    private void FixedUpdate()
    {
        if(_chasing && _playerPosition != null)
        {
            Vector2 direction = _playerPosition.position - transform.position;
            _mb.Move(direction);
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
