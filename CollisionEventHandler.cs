using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace ILYTATTools.Events
{
    public class CollisionEventHandler : MonoBehaviour
    {
        public enum CollisionType { OnBeginCollision, OnExitCollision }

        public CollisionType CollisionToBeginOn;

        [SerializeField]
        private GameObjectEvent eventToOccur;

        private GameObject eventSender;
        public GameObject GetCollidedObject => eventSender;

        public CollisionEventHandler(CollisionType beginWhen, UnityEvent<GameObject> action)
        {
            CollisionToBeginOn = beginWhen;
            eventToOccur = (GameObjectEvent)action;
        }

        public void CollisionEventStart(GameObject sender, float delay = 0.0f)
        {
            //Gameobject is the object with the event, the sender should be who accessed the event by contacting the GameObject.
            GameObject reciever = eventSender;
            Debug.Log(reciever.name + " event occured  (EventBeginsWhen." + CollisionToBeginOn.ToString() + ") and was invoked by " + sender.name);

            if (delay > 0.0f)
            {
                Debug.Log("Waiting " + delay + " seconds before starting.");
                StartCoroutine(WaitBeforeInvoke(sender, delay));
            }
            else
            {
                eventToOccur.Invoke(sender);
            }
            eventToOccur.SetOccured();
        }

        public void SetCollidedObject(GameObject newCO)
        {
            eventSender = newCO;
        }

        private IEnumerator WaitBeforeInvoke(GameObject sender, float delay)
        {
            yield return new WaitForSeconds(delay);
            eventToOccur.Invoke(sender);
        }
    }
}