using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;   
    public float maxValue = 10f;

    public float decrementValue = .2f;
    public float maxDecrementvalue = .5f;

    public float decrementIncreaseFactor = .01f;

    public float addTimeValue = .1f;
    public Slider slider;

    private float currentValue;
    private bool startTimer = false;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        PlayerTap.OnTapEvent += StartTimer;
        GameOverManager.OnGameOver += StopTimer;
    }

    private void OnDisable()
    {
        PlayerTap.OnTapEvent -= StartTimer;
        GameOverManager.OnGameOver -= StopTimer;
    }

    private void Start()
    {
        currentValue = maxValue;

        slider.maxValue = maxValue;
        slider.value = currentValue;
    }

    private void Update()
    {
        if (!startTimer)
        {
            return;
        }

        currentValue -= decrementValue * Time.deltaTime;
        slider.value = currentValue;

        if (currentValue <= 0)
        {
            GameOverManager.instance.GameOver(GameOverManager.GameOverReason.timer);
        }

        decrementValue = Mathf.Min(maxDecrementvalue, decrementValue + decrementIncreaseFactor * Time.deltaTime);
    }

    public void AddTime()
    {
        currentValue = Mathf.Min( maxValue, currentValue + addTimeValue);
        slider.value = currentValue;
    }

    private void StartTimer(bool _)
    {
        if (!startTimer)
        {
            startTimer = true;
        }
    }

    private void StopTimer()
    {
        startTimer = false;
    }
}
