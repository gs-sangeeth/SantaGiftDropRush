using UnityEngine;
using UnityEngine.Events;

public class PlayerTap : MonoBehaviour
{
    public Santa santa;
    public bool isRight = true;

    public static event UnityAction<bool> onTapEvent;

    private void OnMouseDown()
    {

        santa.Move(isRight);

        onTapEvent.Invoke(isRight);

        TimerManager.instance.AddTime();
    }
}
