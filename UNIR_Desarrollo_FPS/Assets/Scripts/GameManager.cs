using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake(){
        if(GameManager.instance != null){
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    //Referencias
    public Player player;
    public BulletManager bulletManager;

    //Recursos
    public int balas = 6;
    public int puntos;

    public void Shoot(Vector3 position, Vector3 direction){
        bulletManager.Shoot(position, direction);
    }
}
