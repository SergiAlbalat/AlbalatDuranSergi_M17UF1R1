using Unity.Cinemachine;
using UnityEngine;

public class Enemy : Character
{
    private Transform _playerPosition;
    private bool _chasing = false;
    private RaycastHit2D ceiling;
    [SerializeField] private LayerMask mapMask;
    private void Start()
    {
        InvokeRepeating("Power", 5, 5);
    }
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
        //Debug.DrawRay(transform.position, transform.up * 15, Color.blue);
        Debug.DrawRay(transform.position, new Vector2(transform.position.x, transform.position.y + ceiling.point.y), Color.yellow);
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
    private void Power()
    {
        ceiling = Physics2D.Raycast(transform.position, transform.up, 15, mapMask);
        if (ceiling)
        {
            Vector2 ceilingPosition = new Vector2(transform.position.x, ceiling.point.y);
            _mb.TeleportCeiling(ceiling.point);
        }
    }
}
