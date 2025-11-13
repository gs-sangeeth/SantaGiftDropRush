using UnityEngine;
using static MovingObject;

public class TilingSpawner : MonoBehaviour
{
    public ObjectType objectTag;
    public float height;
    public int spawnCount = 20;
    public float xPos = 0;


    private float startHeight;
    private float topPos;

    private void OnEnable()
    {
        PlayerTap.OnTapEvent += SpawnNewTile;
    }

    private void OnDisable()
    {
        PlayerTap.OnTapEvent -= SpawnNewTile;
    }

    private void Start()
    {
        startHeight = height * -spawnCount/2;

        float yPos = startHeight;
        for(int i = 0; i < spawnCount; i++)
        {
            SpawnTile(yPos);
            yPos += height;
        }

        topPos = yPos - height;
    }

    private void SpawnNewTile(bool _)
    {
        SpawnTile(topPos);
    }

    private void SpawnTile(float yPos)
    {
        ObjectPooler.instance.SpawnFromPool(objectTag, new Vector2(xPos, yPos));
    }
}
