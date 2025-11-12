using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private float height;

    private void OnEnable()
    {
        PlayerTap.tapEvent += Move;
    }

    private void OnDisable()
    {
        PlayerTap.tapEvent -= Move;
    }

    private void Start()
    {
        height = transform.localScale.y;
    }

    private void Move()
    {
        transform.position += new Vector3(0, -height);

        if (transform.position.y < -12f)
        {
            Destroy(gameObject);
        }
    }
}
