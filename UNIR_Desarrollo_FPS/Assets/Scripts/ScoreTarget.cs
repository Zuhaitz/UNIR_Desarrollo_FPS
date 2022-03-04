using UnityEngine;

public class ScoreTarget : MonoBehaviour
{
    [SerializeField] int points = 5;

    /*
    Detecta la colision con la bala, suma la puntuacion y se destruye
    */
    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag == "Bullet")
        {
            GameManager.instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
