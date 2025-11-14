using Unity.Cinemachine;
using UnityEngine;

public class Enemy : Character
{
    private Transform _playerPosition;
    private bool _chasing = false;
    private void FixedUpdate()
    {
        Vector2 direction;
        if(_chasing && _playerPosition != null)
        {
            direction = new Vector2(_playerPosition.position.x - transform.position.x, 0);
            if (Mathf.Abs(direction.x) <= 0.1f)
                direction = Vector2.zero;
        }
        else
            direction = Vector2.zero;
        _mb.Move(direction);
        Debug.Log(direction.x);
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
