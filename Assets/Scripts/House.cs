using UnityEngine;

public class House : Block, IPooledObject
{
    public ParticleSystem giftEffect;

    [SerializeField]private bool houseGifted = false;

    private void OnEnable()
    {
        PlayerTap.OnTapEvent += CheckMiss;
    }

    private void OnDisable()
    {
        PlayerTap.OnTapEvent -= CheckMiss;
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
                    AudioManager.instance.Play("gift");
                    giftEffect.Play();
                }
            }
            if (!houseGifted)
            {
                GameOverManager.instance.GameOver(GameOverManager.GameOverReason.house);
                print("GameOver House Missed");
            }
        }
    }

    public void OnObjectSpawn()
    {
        houseGifted = false;
    }
}
