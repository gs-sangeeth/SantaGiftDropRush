using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Santa : MonoBehaviour
{
    public const float jumpDuration = .2f;

    public static event UnityAction tapEvent;

    private Vector3 playerScale;

    public bool isRight;

    private void Start()
    {
        playerScale = transform.localScale;
    }

    public void Move(bool isRight)
    {
        this.isRight = isRight;

        DOTween.Kill(transform);

        if (isRight)
        {
            transform.DOMoveX(BlockSpawner.xPos, jumpDuration);
        }
        else
        {
            transform.DOMoveX(-BlockSpawner.xPos, jumpDuration);
        }

        transform.localScale = playerScale;
        transform.DOPunchScale(Vector3.one, jumpDuration, 4)
            .OnComplete(() =>
            { 
                transform.localScale = playerScale;
            });
    }

}
