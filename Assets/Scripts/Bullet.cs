using UnityEngine;

public class Bullet : MonoBehaviour
{
    private MoveBehaviour _mb;
    [SerializeField] private Vector2 direction;
    private void Awake()
    {
        _mb = GetComponent<MoveBehaviour>();
    }
    private void FixedUpdate()
    {
        _mb.Fly(direction);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Dungeon"))
            direction = -direction;
    }
}
