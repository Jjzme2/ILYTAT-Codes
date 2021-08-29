using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEvent : UnityEvent<GameObject>
{

} 

[CreateAssetMenu(fileName = "New Spawnable", menuName = "ILYTAT Tools/Creator/Spawner/ColoredSpawn")]

public class SD_ColoredSpawn : SpawnDataObject
{
    public Color spawnColor;

    public override void AutoFix(GameObject spawnedObj)
    {
        if (spawnedObj.GetComponent<MeshRenderer>() == null)
        {
            Debug.Log("Fixing Mesh Renderer == null");
            spawnedObj.AddComponent<MeshRenderer>();
        }
    }

    public override void EnableGameObjectEvent(GameObject spawnedObj)
    {
        AutoFix(spawnedObj);
        spawnedObj.GetComponent<MeshRenderer>().material.color = spawnColor;
        Debug.Log("Spawning " + SpawnName);
    }
}
