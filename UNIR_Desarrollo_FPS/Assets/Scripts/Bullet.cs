using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public bool active;
    [SerializeField] float speed = 300f;
    float duration = 2f;
    float lastShown;
    
    void Update(){
        if (Time.time - lastShown > duration)
            Hide();
    }

    public void Shoot(Vector3 direction){
        active = true;
        lastShown = Time.time;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(true);
        gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * speed, ForceMode.Impulse);
    }

    private void Hide(){
        active = false;
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision coll){
        //TODO: Hacer algo con la colision
        Hide();
    }
}
