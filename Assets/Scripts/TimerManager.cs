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

    private float currentValue;

    public Slider slider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentValue = maxValue;

        slider.maxValue = maxValue;
        slider.value = currentValue;
    }

    private void Update()
    {
        currentValue -= decrementValue * Time.deltaTime;
        slider.value = currentValue;

        if (currentValue <= 0)
        {
            GameManager.instance.GameOver();
        }

        decrementValue = Mathf.Min(maxDecrementvalue, decrementValue + decrementIncreaseFactor * Time.deltaTime);
    }

    public void AddTime()
    {
        currentValue = Mathf.Min( maxValue, currentValue + addTimeValue);
        slider.value = currentValue;
    }
}
