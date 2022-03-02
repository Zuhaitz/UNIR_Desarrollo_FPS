using UnityEngine;

public class ScoreTarget : MonoBehaviour
{
    [SerializeField] int points = 5;


    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Bullet")
        {
            GameManager.instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
