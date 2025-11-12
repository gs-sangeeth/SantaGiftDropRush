using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isRight;
    public float yPos;

    private void Start()
    {
        yPos = transform.position.y;
    }
}
