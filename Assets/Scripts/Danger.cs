public class Danger : Block
{
    private void OnEnable()
    {
        PlayerTap.onTapEvent += CheckDangerCollision;
    }

    private void OnDisable()
    {
        PlayerTap.onTapEvent -= CheckDangerCollision;
    }

    private void CheckDangerCollision(bool santaIsRight)
    {
        if (yPos == -1.5f)
        {
            if (isRight == santaIsRight)
            {
                GameManager.instance.GameOver();
                print("Game Over Jumped on Tree");
            }
        }

    }
}
