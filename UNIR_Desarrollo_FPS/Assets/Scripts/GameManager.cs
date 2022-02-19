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
    public InterfaceManager interfaceManager;

    //Recursos
    public int bullets = 6;
    public int score;

    public void Shoot(Vector3 position, Vector3 direction){
        if(bullets>0){
            bulletManager.Shoot(position, direction);
            //balas--;
            //TODO: Actualizar interfaz
        }

        if(bullets<=0){
            //TODO: Finalizar partida
        }
    }

    public void AddScore(int points){
        score += points;
        interfaceManager.UpdateScore(score);
    }
}
