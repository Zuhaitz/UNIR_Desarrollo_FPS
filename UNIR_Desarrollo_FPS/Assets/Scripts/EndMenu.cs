using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI i_Score;
    
    void Update()
    {
        //Resetea la escena al detectar la tecla return
        if (Input.GetKeyDown(KeyCode.Return))
            GameManager.instance.RestartScene();
    }

    /*
    Coloca la puntiacion en la pantalla
    */
    public void SetFinalScore(int score){
        i_Score.text = $"Final score: {score}";
    }
}
