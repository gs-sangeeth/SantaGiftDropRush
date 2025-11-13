using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int Score { get { return score; } }

    private int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        PlayerTap.OnTapEvent += IncrementScore;
    }


    private void OnDisable()
    {
        PlayerTap.OnTapEvent -= IncrementScore;
    }

    private void IncrementScore(bool arg0)
    {
        score++;
    }
}
