using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI i_Bullets;
    [SerializeField] TextMeshProUGUI i_Score;
    [SerializeField] GameObject i_EndGame;

    public void UpdateScore(int score){
        i_Score.text = $"Score: {score}";
    }

    public void UpdateBullets(int bullets){
        i_Bullets.text = $"Bullets: {bullets}";
    }

    public void EndGame(int score){
        i_Bullets.enabled = false;
        i_Score.enabled = false;
        i_EndGame.SetActive(true);
    }
}
