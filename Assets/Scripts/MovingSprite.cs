using UnityEngine;
using UnityEngine.UI;

public class MovingSprite : MonoBehaviour
{
    public RawImage image;

    private void OnEnable()
    {
        PlayerTap.OnTapEvent += MoveImage;
    }

    private void OnDisable()
    {
        PlayerTap.OnTapEvent -= MoveImage;
    }

    private void MoveImage(bool _)
    {
        image.uvRect =  new Rect(image.uvRect.position + new Vector2(0,-1.5f), image.uvRect.size);
    }
}
