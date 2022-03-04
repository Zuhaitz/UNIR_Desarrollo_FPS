using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public bool active;
    [SerializeField] float speed = 300f;
    float duration = 2f;
    float lastShown;
    
    void Update(){
        //Comprueba el tiempo que lleva sin colisionar
        if (Time.time - lastShown > duration)
            Hide();
    }

    /*
    Lanza la bala a la direccion señalada
    */
    public void Shoot(Vector3 direction){
        active = true;
        lastShown = Time.time;
        //Resetea la velocidad de la bala
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(true);
        gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * speed, ForceMode.Impulse);
    }

    /*
    Desactiva la bala para reutilizarlo mas tarde
    */
    private void Hide(){
        active = false;
        gameObject.SetActive(false);
        //Avisar al manager que la bala colisiono
        GameManager.instance.bulletCollision();
    }

    /*
    Cuando colisione se desactiva
    */
    void OnCollisionEnter(Collision coll){
        Hide();
    }
}
