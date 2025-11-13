using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> objectPools = new();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.rotation = Quaternion.identity;
                objectPool.Enqueue(obj);
            }

            objectPools.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position)
    {
        if (!objectPools.ContainsKey(tag))
        {
            throw new Exception("Object pool tag does not exist!");
        }

        GameObject objectToSpawn = objectPools[tag].Dequeue();
        objectToSpawn.SetActive(true);
        DOTween.Kill(objectToSpawn.transform);
        objectToSpawn.transform.position = position;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        objectPools[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
}
