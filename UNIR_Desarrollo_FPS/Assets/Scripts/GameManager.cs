using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool gameEnded = false;

    void Start(){
        interfaceManager.UpdateBullets(bullets);
    }

    public void Shoot(Vector3 position, Vector3 direction){
        if(bullets>0){
            bulletManager.Shoot(position, direction);
            bullets--;
            interfaceManager.UpdateBullets(bullets);
        }

        if(bullets<=0){
            //TODO: Finalizar partida
            EndGame();
        }
    }

    public void AddScore(int points){
        score += points;
        interfaceManager.UpdateScore(score);
    }

    private void EndGame(){

        if(!gameEnded){
            gameEnded = true;
            player.StopInput();
            interfaceManager.EndGame(score);
        }
        
    }
}
