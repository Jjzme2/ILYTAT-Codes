using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableDataManager : MonoBehaviour
{
    private MeshRenderer myRend;
    private MeshFilter myFilter;
    private Collider myCol;
    private Rigidbody myRB;
    private SpawnDataObject myData;

    public MeshRenderer GetRend => myRend;
    public MeshFilter GetFilter => myFilter;
    public Collider GetCollider => myCol;
    public Rigidbody GetRigidbody => myRB;
    public SpawnDataObject GetData => myData;

    private void OnEnable()
    {
        SpawnDatabase.AddActiveObject(gameObject);
        myData.EnableGameObjectEvent(gameObject);

    }

    private void OnDisable()
    {
        SpawnDatabase.RemoveActiveObject(gameObject);
    }

    public void InstantiateAll()
    {
        //Rend
        if (GetComponent<MeshRenderer>() == null)
        {
            myRend = gameObject.AddComponent<MeshRenderer>();
            myRend.material = myData.ObjectMaterial;
        }
        else
        {
            myRend = GetComponent<MeshRenderer>();
        }

        //Filter
        if (GetComponent<MeshFilter>() == null)
        {
            myFilter = gameObject.AddComponent<MeshFilter>();
            myFilter.mesh = myData.ObjectMesh;
        }
        else
        {
            myFilter = GetComponent<MeshFilter>();
        }

        //Rigidbody
        if (GetComponent<Rigidbody>() == null)
        {
            myRB = gameObject.AddComponent<Rigidbody>();
            myRB.isKinematic = true;
        }
        else
        {
            myRB = GetComponent<Rigidbody>();
        }

        //Collider
        if (GetComponent<Collider>() == null)
        {
            myCol = gameObject.AddComponent<MeshCollider>();
        }
        else
        {
            myCol = GetComponent<MeshCollider>();
        }
    }

    public void SetData(SpawnDataObject data)
    {
        myData = data;
    }

    public void Activate()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        else { print(name + " is already active in the hierarchy."); }
    }

    public void Deactivate()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else { print(name + " is not active in the hierarchy."); }
    }
}
