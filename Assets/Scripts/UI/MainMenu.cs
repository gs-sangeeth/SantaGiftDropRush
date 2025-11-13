using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playButton;
    private void Start()
    {
        playButton.transform.DOPunchScale(Vector3.one * .1f, 1, 1).SetLoops(-1);

        AudioManager.instance.Play("bgm");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        AudioManager.instance.Play("button");
    }
}
