using UnityEngine;
using UnityEngine.UI;

public class MovingSprite : MonoBehaviour
{
    public RawImage image;

    private void Update()
    {
        image.uvRect =  new Rect(image.uvRect.position + new Vector2(.1f,.1f) * Time.deltaTime, image.uvRect.size);
    }
}
