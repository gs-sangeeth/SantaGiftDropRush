using UnityEngine;
using UnityEngine.Events;

public class PlayerTap : MonoBehaviour
{
    public Santa santa;

    public static event UnityAction<bool> onTapEvent;

    public void Tap(bool isRight)
    {
        santa.Move(isRight);

        onTapEvent.Invoke(isRight);

        TimerManager.instance.AddTime();
    }
}
