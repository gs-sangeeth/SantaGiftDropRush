using System;
using UnityEngine;

public class TilingSpawner : MonoBehaviour
{
    public GameObject obj;
    public float height;
    public int spawnCount = 20;

    private float startHeight;
    private float topPos;

    private void OnEnable()
    {
        PlayerTap.tapEvent += SpawnNewTile;
    }

    private void OnDisable()
    {
        PlayerTap.tapEvent -= SpawnNewTile;
    }

    private void Start()
    {
        startHeight = height * -spawnCount/2;

        float yPos = startHeight;
        for(int i = 0; i < spawnCount; i++)
        {
            Instantiate(obj, new Vector2(0, yPos), Quaternion.identity);
            yPos += height;
        }

        topPos = yPos - height;
    }

    private void SpawnNewTile()
    {
        Instantiate(obj, new Vector2(0, topPos), Quaternion.identity);
    }
}
