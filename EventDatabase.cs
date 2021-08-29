using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ILYTATTools.Extensions;
using System;

namespace ILYTATTools.Events
{
    [System.Serializable]
    public class GameObjectEvent : UnityEvent<GameObject>
    {
        public int TimesRepeated { get; private set; }
        public bool HasOccured { get; private set; }

        public void SetOccured()
        {
            if (TimesRepeated == 0)
            {
                HasOccured = true;
            }
            else
            {
                TimesRepeated++;
            }
        }
    }

    public class EventDatabase : MonoBehaviour
    {
        public static EventDatabase Instance { get; private set; }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


        //Events that can happen and be chosen should be put here.
        public void SendMessageToConsole(string message)
        {
            Debug.Log(message);
        }

        public void ColorRed(GameObject sender)
        {
            sender.GetComponent<SpriteController>().GetRend.color = Color.red;
        }

        public void ColorWhite(GameObject sender)
        {
            sender.GetComponent<SpriteController>().GetRend.color = Color.white;
        }

        public void ColorBlue(GameObject sender)
        {
            sender.GetComponent<SpriteController>().GetRend.color = Color.blue;
        }

        //public static void Collect(GameObject sender)
        //{
        //    print("Sender: " + sender.name);
        //    GameObject collidedObj = sender.GetComponentInChildren<CollisionDetector2D>().GetCollidedObj;
        //    sender.GetComponent<Collector>().CollectIt(collidedObj);
        //}
    }
}