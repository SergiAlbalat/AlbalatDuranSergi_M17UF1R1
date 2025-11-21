using UnityEngine;
[RequireComponent (typeof(MoveBehaviour))]
public class Bullet : MonoBehaviour
{
    private MoveBehaviour _mB;
    [SerializeField] private Vector2 direction;
    private BulletPool bulletPool;
    private void Awake()
    {
        _mB = GetComponent<MoveBehaviour>();
        bulletPool = FindAnyObjectByType<BulletPool>();
    }
    private void FixedUpdate()
    {
        _mB.Fly(direction);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Dungeon"))
        {
            bulletPool.StoreBullet(this);
        }
    }
}
