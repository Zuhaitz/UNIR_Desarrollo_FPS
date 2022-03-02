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
        //DontDestroyOnLoad(gameObject);
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
        bullets = player.gun.bullets;
        interfaceManager.UpdateBullets(bullets);      
    }

    public void Shoot(Vector3 position, Vector3 direction){
        if(bullets>0){
            bulletManager.Shoot(position, direction);
            bullets--;
            interfaceManager.UpdateBullets(bullets);
        }
    }

    public void bulletCollision(){
        if(bullets<=0)
            Invoke("EndGame", 0.5f);
    }

    public void AddScore(int points){
        score += points;
        interfaceManager.UpdateScore(score);
    }

    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void EndGame(){

        if(!gameEnded){
            gameEnded = true;
            player.StopInput();
            interfaceManager.EndGame(score);
        }
        
    }
    
}
