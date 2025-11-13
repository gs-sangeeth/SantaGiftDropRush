using DG.Tweening;
using UnityEngine;

public class MovingObject : MonoBehaviour, IPooledObject
{
    public ObjectType type;
    private const float moveDistance = 1.5f;
    public Block block;

    float newYPos;

    Renderer rd;

    private void OnEnable()
    {
        PlayerTap.OnTapEvent += Move;
    }

    private void OnDisable()
    {
        PlayerTap.OnTapEvent -= Move;
    }

    private void Start()
    {
        newYPos = transform.position.y;
        rd = GetComponent<Renderer>();
    }

    private void Move(bool _)
    {
        newYPos = newYPos - moveDistance;
        if (block != null)
        {
            block.yPos = newYPos;
        }
        transform.DOMoveY(newYPos, Santa.jumpDuration);

        if (transform.position.y< -12)
        {
            ObjectPooler.instance.ReturnObjectToPool(type, gameObject);
        }
    }

    public void OnObjectSpawn()
    {
        newYPos = transform.position.y;
    }

    public enum ObjectType
    {
        house,
        danger,
        road,
        ground,
        blank,
        decor
    }
}
