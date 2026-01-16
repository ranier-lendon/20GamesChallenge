using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score1 = 0, score2 = 0;
    [SerializeField] private GameObject paddles;
    [SerializeField] private GameObject ball;
    
    public void AddScore(float xDir)
    {
        if (xDir > 0) score1++;
        else score2++;

        UpdateUI();
        GameReset();
    }

    void UpdateUI()
    {
        scoreText.text = $"{score1} - {score2}";
    }

    void GameReset()
    {
        Transform paddle1 = paddles.transform.GetChild(0).gameObject.transform;
        Transform paddle2 = paddles.transform.GetChild(1).gameObject.transform;
        BallScript ballScript = ball.GetComponent<BallScript>();

        paddle1.position = new Vector2(-8, 0);
        paddle2.position = new Vector2(8, 0);
        ballScript.Reset();
    }
    
}
