using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefabs;
    public int size;
}

public class ObjectPooler : MonoBehaviour {

    #region Singleton
    public static ObjectPooler Instance;

    /*private void Awake()
    {
        Instance = this;
    }*/
    #endregion

    public Pool[] pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    [HideInInspector]
    public List<GameObject> spawnedHazards;

    void Awake() {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        for (int i = 0; i < pools.Length; i++)
        {
                Pool pool = pools[i];
           
                Queue<GameObject> objectPool = new Queue<GameObject>();

                //при большом количестве объектов
                //for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefabs);
                obj.transform.SetParent(transform, false);//препятствия назначаются детьми спавнера
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                // }

                poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + "is not exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        spawnedHazards.Add(objectToSpawn);//добавляем препятствие в массив, который помогает определить препятствие перед игроком

       // IPooledObject poolObj = objectToSpawn.GetComponent<IPooledObject>();
      //  if (poolObj != null)
         //   poolObj.OnObjectSpawn();
            
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }
}
