using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blankBlockPrefab;
    public GameObject houseBlockPrefab;
    public GameObject dangerBlockPrefab;

    public float difficultyIncreaseRate = 0.1f;

    public float dangerProbability = 0.3f;
    public float houseProbability = 0.2f;

    public const float xPos = 1.2f;

    private void OnEnable()
    {
        PlayerTap.tapEvent += SpawnNewBlocks;
    }

    private void OnDisable()
    {
        PlayerTap.tapEvent -= SpawnNewBlocks;
    }

    private void Start()
    {
        float y = -7.5f;
        while (y <= 7.5f)
        {
            SpawnBlocks(yPosition: y, onlyBlanks: true);
            y += 1.5f;
        }
    }

    private void SpawnNewBlocks()
    {
        SpawnBlocks();

        dangerProbability += difficultyIncreaseRate * .02f;
        houseProbability += difficultyIncreaseRate * .01f;

        dangerProbability = Mathf.Min(0.9f, dangerProbability);
        houseProbability = Mathf.Min(0.4f, houseProbability);
    }

    void SpawnBlocks(float yPosition = 7.5f, bool onlyBlanks = false)
    {
        GameObject leftBlock = blankBlockPrefab;
        GameObject rightBlock = blankBlockPrefab;

        if (onlyBlanks)
        {
            SpawnBlock(leftBlock, new Vector2(-xPos, yPosition));
            SpawnBlock(rightBlock, new Vector2(xPos, yPosition));

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
            GameObject blockType = blankBlockPrefab;

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

        SpawnBlock(leftBlock, new Vector2(-xPos, yPosition));
        SpawnBlock(rightBlock, new Vector2(xPos, yPosition));
    }

    void SpawnBlock(GameObject prefab, Vector2 spawnPos)
    {
        GameObject block = Instantiate(prefab, spawnPos, Quaternion.identity);
    }

}
