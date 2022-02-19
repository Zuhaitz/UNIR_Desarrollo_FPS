using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject i_Bullets;
    [SerializeField] TextMeshProUGUI i_Score;

    public void UpdateScore(int score){
        i_Score.text = $"Score: {score}";
    }
}
