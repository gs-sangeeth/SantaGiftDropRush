using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Block blankBlockPrefab;
    public Block houseBlockPrefab;
    public Block dangerBlockPrefab;

    public float difficultyIncreaseRate = 0.1f;

    public float dangerProbability = 0.3f;
    public float houseProbability = 0.2f;

    public const float xPos = 1.2f;

    private const float blockHeight = 1.5f;
    private const float spawnHeight = blockHeight * blockCount / 2;
    private const int blockCount = 10;

    private void OnEnable()
    {
        PlayerTap.onTapEvent += SpawnNewBlocks;
    }

    private void OnDisable()
    {
        PlayerTap.onTapEvent -= SpawnNewBlocks;
    }

    private void Start()
    {
        SpawnStartingBlocks();
    }

    private void SpawnStartingBlocks()
    {
        float y = -spawnHeight;
        while (y <= spawnHeight)
        {
            if (y <= 0)
            {
                SpawnBlocks(yPosition: y, onlyBlanks: true);
            }
            else
            {
                SpawnBlocks(yPosition: y, onlyBlanks: false);
            }
            y += blockHeight;
        }
    }

    private void SpawnNewBlocks(bool _)
    {
        SpawnBlocks();

        dangerProbability += difficultyIncreaseRate * .02f;
        houseProbability += difficultyIncreaseRate * .01f;

        dangerProbability = Mathf.Min(0.9f, dangerProbability);
        houseProbability = Mathf.Min(0.4f, houseProbability);
    }

    void SpawnBlocks(float yPosition = spawnHeight, bool onlyBlanks = false)
    {
        Block leftBlock = blankBlockPrefab;
        Block rightBlock = blankBlockPrefab;

        if (onlyBlanks)
        {
            InstantiateBlocks(yPosition, leftBlock, rightBlock);
            return;
        }

        bool dangerChance = Random.value < dangerProbability;
        bool houseChance = Random.value < houseProbability;

        bool isLeft = Random.value > .5f;

        if (dangerChance && houseChance)
        {
            if (isLeft)
            {
                leftBlock = dangerBlockPrefab;
                rightBlock = houseBlockPrefab;
            }
            else
            {
                leftBlock = houseBlockPrefab;
                rightBlock = dangerBlockPrefab;
            }
        }
        else
        {
            Block blockType = blankBlockPrefab;

            if (dangerChance)
            {
                blockType = dangerBlockPrefab;
            }
            if (houseChance)
            {
                blockType = houseBlockPrefab;
            }

            if (isLeft)
            {
                leftBlock = blockType;
            }
            else
            {
                rightBlock = blockType;
            }
        }

        InstantiateBlocks(yPosition, leftBlock, rightBlock);
    }

    private static void InstantiateBlocks(float yPosition, Block leftBlock, Block rightBlock)
    {
        Block lBlock = Instantiate(leftBlock, new Vector2(-xPos, yPosition), Quaternion.identity);
        Block rBlock = Instantiate(rightBlock, new Vector2(xPos, yPosition), Quaternion.identity);

        lBlock.isRight = false;
        rBlock.isRight = true;
    }
}
