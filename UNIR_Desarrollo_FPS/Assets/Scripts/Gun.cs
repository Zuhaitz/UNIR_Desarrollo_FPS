using UnityEngine;

public class Gun : MonoBehaviour
{
    //Referencias
    Camera mainCamera;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Animator anim;
    [SerializeField] GameObject flashPrefab;

    [Header("Stats Settings")]
    public int bullets = 6;
    [SerializeField] float fireSpeed = 0.2f;
    
    float lastShoot;

    void Start(){
        mainCamera = Camera.main;
    }

    /*
    Dispara una bala si quedan y se termino el tiempo de espera
    */
    public void Shoot(){
        if (Time.time - lastShoot > fireSpeed && bullets>0){
            lastShoot = Time.time;
            anim.SetTrigger("Fire");
            //Invoca el fogonazo
            GameObject flash = Instantiate(flashPrefab, bulletSpawn.position, bulletSpawn.rotation);
            Destroy(flash, 1f);

            //Calcula la direccion y disparamos
            Vector3 direction = CalculateDirection();
            GameManager.instance.Shoot(bulletSpawn.position, direction);
            bullets--;
        }
    }

    /*
    Calcula la direccion que debe cruzar la bala
    */
    private Vector3 CalculateDirection(){
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //Detecta la colision o un punto distante desde el centro de la camara
        Vector3 target;
        if(Physics.Raycast(ray, out hit))
            target = hit.point;
        else
            target = ray.GetPoint(75);

        //calcula el vecto y lo devuelve
        return target - bulletSpawn.position;
    }

}
