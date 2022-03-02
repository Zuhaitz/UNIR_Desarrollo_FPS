using UnityEngine;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI i_Score;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            GameManager.instance.RestartScene();
    }

    public void SetFinalScore(int score){
        i_Score.text = $"Final score: {score}";
    }
}
