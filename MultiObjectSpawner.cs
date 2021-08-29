using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ILYTATTools.Extensions;
using System.Linq;

public static class SpawnDatabase
{
    private static List<GameObject> spawnedObjects = new List<GameObject>();
    public static List<GameObject> GetSpawnedObjects => spawnedObjects;
    private static List<GameObject> activeGameObjects = new List<GameObject>();
    public static List<GameObject> GetActiveGameObjects => activeGameObjects;



    public static void AddSpawnedObject(GameObject gameObjectToAdd)
    {
        if (!spawnedObjects.Contains(gameObjectToAdd))
        {
            spawnedObjects.Add(gameObjectToAdd);
        }
        else
        {
            Debug.Log("Spawned Objects already contains " + gameObjectToAdd.name);
        }
    }

    public static void RemoveSpawnedObject(GameObject gameObjectToRemove)
    {
        if (spawnedObjects.Contains(gameObjectToRemove))
        {
            spawnedObjects.Remove(gameObjectToRemove);
        }
        else
        {
            Debug.Log("Spawned Objects doesn't contain " + gameObjectToRemove.name);
        }
    }

    public static void AddActiveObject(GameObject gameObjectToAdd)
    {
        if (!activeGameObjects.Contains(gameObjectToAdd))
        {
            activeGameObjects.Add(gameObjectToAdd);
        }
        else
        {
            Debug.Log("Active Objects already contains " + gameObjectToAdd.name);
        }
    }

    public static void RemoveActiveObject(GameObject gameObjectToRemove)
    {
        if (activeGameObjects.Contains(gameObjectToRemove))
        {
            activeGameObjects.Remove(gameObjectToRemove);
        }
        else
        {
            Debug.Log("Active Objects doesn't contain " + gameObjectToRemove.name);
        }
    }

    public static List<GameObject> GetGameObjectsWithData(SpawnDataObject spawnData)
    {
        List<GameObject> returned = new List<GameObject>();
        var spawnWithData = from s in spawnedObjects
                            where s.GetComponent<SpawnableDataManager>().GetData == spawnData
                            select s;

        foreach (var d in spawnWithData)
        {
            returned.Add(d.gameObject);
        }
        if (returned.Count > 1)
        {
            return returned;
        }
        else
        {
            Debug.LogError("No Spawns with spawn data named: " + spawnData.SpawnName + " were able to be returned.");
            return null;
        }
    }
}

public class MultiObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private bool spawnOnEnable = false;
    public List<SpawnDataObject> Spawnables = new List<SpawnDataObject>();
    [SerializeField]
    private int childrenToSpawn = 3;
    
    private void OnEnable()
    {
        if (spawnOnEnable)
        {
            SpawnRandomChildren();
        }
    }

    public void BeginSpawn()
    {
        SpawnRandomChildren();
    }

    public void BeginSpawn(SpawnDataObject data)
    {
        SpawnObject(data);
    }

    private void SpawnRandomChildren()
    {
        DeleteAllCurrentSpawns();

        for(int i = 0; i < childrenToSpawn; i++)
        {
            SpawnObject();
        }
        DeactivateAllSpawns();
    }

    private void DeactivateAllSpawns()
    {

    }

    private void DeleteAllCurrentSpawns()
    {
       foreach(GameObject go in transform.GetChildren())
        {
            if(go.GetComponent<SpawnableDataManager>() != null)
            {
                Destroy(go);
            }
        }
    }

    private void SpawnObject()
    {
        int ran = Random.Range(0, Spawnables.Count);

        Spawn(Spawnables[ran]);
    }

    private void Spawn(SpawnDataObject spawnDataObject)
    {
        //Other Data
        float minX = -70;
        float maxX = 70;
        float minY = 0;
        float maxY = 0;
        float minZ = -50;
        float maxZ = 50;

        float ranX = Random.Range(minX, maxX);
        float ranY = Random.Range(minY, maxY);
        float ranZ = Random.Range(minZ, maxZ);

        GameObject go = new GameObject();

        //Create Spawn
        GameObject spawn = go;
        spawn.transform.parent = transform;
        SpawnDataObject data = spawnDataObject;
        SpawnableDataManager dataManager = spawn.AddComponent<SpawnableDataManager>();
        MeshFilter filter = spawn.AddComponent<MeshFilter>();
        SpawnDatabase.AddSpawnedObject(spawn);

        //Apply needed info
        spawn.transform.localPosition = new Vector3(ranX, ranY, ranZ);
        filter.mesh = data.ObjectMesh;
        spawn.name = "Spawned " + data.SpawnName;
        dataManager.SetData(data);
        dataManager.InstantiateAll();
    }

    private void SpawnObject(SpawnDataObject data)
    {
        Spawn(data);
    }
}