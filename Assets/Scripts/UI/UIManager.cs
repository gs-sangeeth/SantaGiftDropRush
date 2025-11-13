using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private int tapCount = 0;

    public GameObject panel2;
    public GameObject panel3;
    public GameObject FTUEPanel;
    public GameObject tapIndicators;

    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        PlayerTap.OnTapEvent += DisableIndicator;
        PlayerTap.OnTapEvent += UpdateScore;
    }

    private void OnDisable()
    {
        PlayerTap.OnTapEvent -= DisableIndicator;
        PlayerTap.OnTapEvent -= UpdateScore;
    }

    private void Start()
    {
        tapIndicators.transform.DOPunchScale(new Vector3(.1f, 0, 0), 1, 1).SetLoops(-1);
    }

    public void OnFTUETap()
    {
        tapCount++;
        switch (tapCount)
        {
            case 1:
                panel2.SetActive(true);
                break;
            case 2:
                panel3.SetActive(true);
                break;
            case 3:
                FTUEPanel.SetActive(false);
                break;
        }

        AudioManager.instance.Play("button");
    }

    private void DisableIndicator(bool _)
    {
        tapIndicators.SetActive(false);
    }

    private void UpdateScore(bool _)
    {
        scoreText.text = ScoreManager.instance.Score.ToString();
    }
}
