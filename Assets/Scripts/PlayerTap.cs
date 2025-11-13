using UnityEngine;
using UnityEngine.Events;

public class PlayerTap : MonoBehaviour
{
    public Santa santa;

    public static event UnityAction<bool> OnTapEvent;

    public void Tap(bool isRight)
    {
        if (GameOverManager.instance.IsGameOver)
        {
            return;
        }

        santa.Move(isRight);

        OnTapEvent.Invoke(isRight);

        TimerManager.instance.AddTime();

        AudioManager.instance.Play("jump");
    }
}
