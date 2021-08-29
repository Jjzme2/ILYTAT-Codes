using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SpawnDataObject : ScriptableObject
{
    public GameObject GetGameObject { get; }
    public Vector3 GetPosition { get; }
    public SpawnableDataManager GetSpawnManager { get; }

    public string SpawnName;
    public Material ObjectMaterial;
    public Mesh ObjectMesh;

    public abstract void EnableGameObjectEvent(GameObject spawnedObj);
    public abstract void AutoFix(GameObject spawnedObj);
}
