using UnityEngine;

public class House : Block
{
    [SerializeField]private bool houseGifted = false;

    private void OnEnable()
    {
        PlayerTap.onTapEvent += CheckMiss;
    }

    private void OnDisable()
    {
        PlayerTap.onTapEvent -= CheckMiss;
    }

    private void CheckMiss(bool santaIsRight)
    {
        if (yPos < 0)
        {
            if (yPos == -1.5f)
            {
                if(isRight == santaIsRight)
                {
                    houseGifted = true;
                }
            }
            if (!houseGifted)
            {
                print("GameOver House Missed");
            }
        }
    }
}
