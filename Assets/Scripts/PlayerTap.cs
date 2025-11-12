using UnityEngine;
using UnityEngine.Events;

public class PlayerTap : MonoBehaviour
{
    public Transform santa;
    public bool isRight = true;

    public static event UnityAction tapEvent;

    private void OnMouseDown()
    {
        if (isRight)
        {
            santa.position = new Vector2(BlockSpawner.xPos, santa.position.y);
        }
        else
        {
            santa.position = new Vector2(-BlockSpawner.xPos, santa.position.y);
        }

        tapEvent.Invoke();
    }
}
