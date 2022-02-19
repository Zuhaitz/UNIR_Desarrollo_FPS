using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTarget : MonoBehaviour
{
    [SerializeField] int points = 5;


    void OnCollisionEnter(Collision coll){
        Debug.Log(coll.gameObject.tag);
        if(coll.gameObject.tag == "Bullet")
        {
            GameManager.instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
