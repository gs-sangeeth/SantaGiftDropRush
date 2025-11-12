using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTap : MonoBehaviour
{
    public Transform santa;
    public bool isRight = true;
    public const float jumpDuration = .2f;

    public static event UnityAction tapEvent;

    private Vector3 playerScale;

    private void Start()
    {
        playerScale = santa.localScale;

        santa.DOShakeScale(1,.1f,1).SetLoops(-1);
    }

    private void OnMouseDown()
    {
        if (isRight)
        {
            santa.DOMoveX(BlockSpawner.xPos, jumpDuration);
        }
        else
        {
            santa.DOMoveX(-BlockSpawner.xPos, jumpDuration);
        }

        santa.DOPunchScale(Vector3.one, jumpDuration, 4).OnComplete(()=> santa.localScale = playerScale);

        tapEvent.Invoke();
    }
}
