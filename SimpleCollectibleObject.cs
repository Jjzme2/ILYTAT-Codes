using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ILYTATTools.Collector
{

    public class SimpleCollectibleObject : MonoBehaviour, ICollectible
    {
        public GameObject GetGameObject { get; }

        public void Collect(GameObject sender)
        {
            sender.GetComponent<Collector>().CollectThis(gameObject);
            gameObject.SetActive(false);
        }
    }
}