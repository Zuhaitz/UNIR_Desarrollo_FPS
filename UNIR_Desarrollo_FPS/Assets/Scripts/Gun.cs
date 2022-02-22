using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Camera mainCamera;
    float lastShoot;
    [SerializeField] float fireSpeed = 0.2f;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Animator anim;
    [SerializeField] GameObject flashPrefab;

    void Start(){
        mainCamera = Camera.main;
    }

    public void Shoot(){
        if (Time.time - lastShoot > fireSpeed){
            lastShoot = Time.time;
            anim.SetTrigger("Fire");
            GameObject flash = Instantiate(flashPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Destroy(flash, 1f);


            Vector3 direction = CalculateDirection();
            GameManager.instance.Shoot(bulletSpawn.position, direction);

        }
    }

    private Vector3 CalculateDirection(){
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 target;
        if(Physics.Raycast(ray, out hit))
            target = hit.point;
        else
            target = ray.GetPoint(75);

        return target - bulletSpawn.position;
    }

}
