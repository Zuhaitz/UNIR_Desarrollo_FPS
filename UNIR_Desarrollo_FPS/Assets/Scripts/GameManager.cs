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
        //Recogemos el numero de balas del jugador
        bullets = player.gun.bullets;
        //Actualizamos la interfaz
        interfaceManager.UpdateBullets(bullets);      
    }

    /*
    Dada la posicion donde sale la bala y la direccion, dispara la bala si quedan
    */
    public void Shoot(Vector3 position, Vector3 direction){
        if(bullets>0){
            bulletManager.Shoot(position, direction);
            bullets--;
            interfaceManager.UpdateBullets(bullets);
        }
    }

    /*
    Si colisiona la ultima bala termina el juego
    */
    public void bulletCollision(){
        if(bullets<=0)
            Invoke("EndGame", 0.5f);
    }

    /*
    Añade la puntuacion al total
    */
    public void AddScore(int points){
        score += points;
        interfaceManager.UpdateScore(score);
    }

    /*
    Reinicia la partida
    */
    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*
    Termina el juego
    */
    private void EndGame(){
        if(!gameEnded){
            gameEnded = true;
            player.StopInput();
            interfaceManager.EndGame(score);
        }
        
    }
    
}
