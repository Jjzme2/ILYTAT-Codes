using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Collector
{
    [RequireComponent(typeof(Inventory))]
    public class Collector : MonoBehaviour
    {
        private Inventory inventory => GetComponent<Inventory>();
        public Inventory GetInventory => inventory;

        public void CollectThis(GameObject gameObjectToCollect)
        {
            print("Attempting Collection.");
            ICollectible collectible;

            if ((gameObjectToCollect.GetComponent(typeof(ICollectible)) != null))
                collectible = (ICollectible)gameObjectToCollect.GetComponent(typeof(ICollectible));
            else if (gameObjectToCollect.transform.parent.GetComponent(typeof(ICollectible)) != null)
                collectible = (ICollectible)gameObjectToCollect.transform.parent.GetComponent(typeof(ICollectible));
            else if (gameObjectToCollect.GetComponentInChildren(typeof(ICollectible)) != null)
                collectible = (ICollectible)gameObjectToCollect.GetComponentInChildren(typeof(ICollectible));
            else
            {
                print("Is " + gameObjectToCollect.name + " marked as ICollectible?");
                return;
            }
            GetInventory.AddItem(gameObjectToCollect);
            collectible.Collect(gameObject);
        }
    }
}