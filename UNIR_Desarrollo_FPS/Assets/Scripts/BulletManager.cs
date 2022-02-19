using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    private List<GameObject> bullets = new List<GameObject>();

    public void Shoot(Vector3 position, Vector3 direction){
        GameObject bullet = GetBullet();

        bullet.transform.position = position;
        bullet.transform.forward = direction.normalized;
        bullet.GetComponent<Bullet>().Shoot(direction);
    }

    private GameObject GetBullet(){
        GameObject bullet = bullets.Find(b => !b.GetComponent<Bullet>().active);

        if (bullet == null){
            bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }

        return bullet;
    }
}
