using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverScreen;

    public static event UnityAction OnGameOver;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        OnGameOver.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
