using DG.Tweening;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private const float moveDistance = 1.5f;

    private void OnEnable()
    {
        PlayerTap.tapEvent += Move;
    }

    private void OnDisable()
    {
        PlayerTap.tapEvent -= Move;
    }

    private void Move()
    {
        transform.DOMoveY(transform.position.y - moveDistance, PlayerTap.jumpDuration);

        if (transform.position.y < -12f)
        {
            Destroy(gameObject);
        }
    }
}
