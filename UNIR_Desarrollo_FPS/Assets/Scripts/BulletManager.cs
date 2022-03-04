using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private List<GameObject> bullets = new List<GameObject>();

    /*
    Dada la posicion donde sale la bala y la direccion, dispara la bala
    */
    public void Shoot(Vector3 position, Vector3 direction){
        //Pedir una bala
        GameObject bullet = GetBullet();

        //Ubicar y disparar la bala
        bullet.transform.position = position;
        bullet.transform.forward = direction.normalized;
        bullet.GetComponent<Bullet>().Shoot(direction);
    }

    /*
    Devuelve una bala que no este en uso, sino crea uno
    */
    private GameObject GetBullet(){
        GameObject bullet = bullets.Find(b => !b.GetComponent<Bullet>().active);

        //Si no hay balas disponibles, crea una
        if (bullet == null){
            bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }

        return bullet;
    }
    
}
