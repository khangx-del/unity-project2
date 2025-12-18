using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public PlayerScript player;
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    private void Start()
    {
        UpdateScoreText();
    }
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {playerScore}";
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
