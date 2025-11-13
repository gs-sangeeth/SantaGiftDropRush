using Unity.Android.Gradle;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Block houseBlockPrefab;
    public Block dangerBlockPrefab;

    public float difficultyIncreaseRate = 0.1f;

    public float dangerProbability = 0.3f;
    public float houseProbability = 0.2f;

    public const float xPos = 1.2f;

    private const float blockHeight = 1.5f;
    private const float spawnHeight = blockHeight * blockCount / 2;
    private const int blockCount = 10;

    private const string houseTag = "House";
    private const string dangerTag = "Danger";

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
        string leftBlock = null;
        string rightBlock = null;

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
                leftBlock = dangerTag;
                rightBlock = houseTag;
            }
            else
            {
                leftBlock = houseTag;
                rightBlock = dangerTag;
            }
        }
        else
        {
            string blockType = null;

            if (dangerChance)
            {
                blockType = dangerTag;
            }
            if (houseChance)
            {
                blockType = houseTag;
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

    private static void InstantiateBlocks(float yPosition, string leftBlock, string rightBlock)
    {
        if (leftBlock != null)
        {
            GameObject obj = ObjectPooler.instance.SpawnFromPool(leftBlock, new Vector2(-xPos, yPosition));
            obj.GetComponent<Block>().isRight = false;
        }

        if (rightBlock != null)
        {
            GameObject obj = ObjectPooler.instance.SpawnFromPool(rightBlock, new Vector2(xPos, yPosition));
            obj.GetComponent<Block>().isRight = true;
        }
    }
}
