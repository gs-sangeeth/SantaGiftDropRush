using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public GameObject timerReason;
    public GameObject houseReason;
    public GameObject dangerReason;

    public static event UnityAction OnGameOver;

    private const string highScoreKey = "HighScore";

    private void Awake()
    {
        instance = this;
    }

    public void GameOver(GameOverReason reason)
    {
        gameOverScreen.SetActive(true);
        OnGameOver.Invoke();

        scoreText.text = ScoreManager.instance.Score.ToString();

        if (PlayerPrefs.GetInt(highScoreKey) < ScoreManager.instance.Score)
        {
            PlayerPrefs.SetInt(highScoreKey, ScoreManager.instance.Score);
        }

        highScoreText.text = PlayerPrefs.GetInt(highScoreKey).ToString();

        switch (reason)
        {
            case GameOverReason.timer:
                timerReason.SetActive(true);
                break;
            case GameOverReason.house:
                houseReason.SetActive(true);
                break;
            case GameOverReason.danger:
                dangerReason.SetActive(true);
                break;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public enum GameOverReason
    {
        timer,
        house,
        danger
    }
}
