using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    private Stack<Bullet> bullets = new Stack<Bullet>();
    private void Start()
    {
        InvokeRepeating("ShootBullet", 0, 1);
    }
    private Bullet ShootBullet()
    {
        if(bullets.Count > 0)
        {
            Bullet bullet = bullets.Pop();
            bullet.transform.position = transform.position;
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            return bullet;
        }
    }
    public void StoreBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullets.Push(bullet);
    }
}
