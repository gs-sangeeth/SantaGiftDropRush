using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static MovingObject;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    public List<Pool> pools;
    public Dictionary<ObjectType, Queue<GameObject>> objectPools = new();

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
                AddNewObjectInPool(pool, objectPool);
            }

            objectPools.Add(pool.tag, objectPool);
        }
    }

    private static void AddNewObjectInPool(Pool pool, Queue<GameObject> objectPool)
    {
        GameObject obj = Instantiate(pool.prefab);
        obj.SetActive(false);
        obj.transform.rotation = Quaternion.identity;
        objectPool.Enqueue(obj);
    }

    public GameObject SpawnFromPool(ObjectType tag, Vector3 position)
    {
        if (!objectPools.ContainsKey(tag))
        {
            throw new Exception("Object pool tag does not exist!");
        }

        if (objectPools[tag].Count == 0)
        {
            AddNewObjectInPool(pools.Where(x => x.tag == tag).First(), objectPools[tag]);
        }

        GameObject objectToSpawn = objectPools[tag].Dequeue();
        objectToSpawn.SetActive(true);
        DOTween.Kill(objectToSpawn.transform);
        objectToSpawn.transform.position = position;

        IPooledObject[] pooledObjInterfaces = objectToSpawn.GetComponents<IPooledObject>();
        if (pooledObjInterfaces != null)
        {
            foreach(IPooledObject obj in pooledObjInterfaces)
            {
                obj.OnObjectSpawn();
            }
        }

        return objectToSpawn;
    }

    public void ReturnObjectToPool(ObjectType tag, GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objectPools[tag].Enqueue(objectToReturn);
    }

    [Serializable]
    public class Pool
    {
        public ObjectType tag;
        public GameObject prefab;
        public int size;
    }
}
