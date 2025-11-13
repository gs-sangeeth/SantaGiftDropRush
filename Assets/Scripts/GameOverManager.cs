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

    public static event UnityAction OnGameOver;

    private const string highScoreKey = "HighScore";

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        OnGameOver.Invoke();

        scoreText.text = ScoreManager.instance.Score.ToString();

        if(PlayerPrefs.GetInt(highScoreKey)< ScoreManager.instance.Score)
        {
            PlayerPrefs.SetInt(highScoreKey, ScoreManager.instance.Score);
        }

        highScoreText.text = PlayerPrefs.GetInt(highScoreKey).ToString();

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
