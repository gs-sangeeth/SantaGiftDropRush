using DG.Tweening;
using UnityEngine;

public class FTUE : MonoBehaviour
{
    private int tapCount = 0;

    public GameObject panel2;
    public GameObject panel3;
    public GameObject FTUEPanel;
    public GameObject tapIndicators;

    private void OnEnable()
    {
        PlayerTap.OnTapEvent += DisableIndicator;
    }

    private void OnDisable()
    {
        PlayerTap.OnTapEvent -= DisableIndicator;
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
                tapIndicators.SetActive(true);
                tapIndicators.transform.DOPunchScale(new Vector3(.1f,0,0),1,1).SetLoops(-1);
                FTUEPanel.SetActive(false);
                break;
        }
    }

    private void DisableIndicator(bool _)
    {
        tapIndicators.SetActive(false);
    }
}
