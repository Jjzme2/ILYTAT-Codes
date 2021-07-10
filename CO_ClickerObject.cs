using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = ILYTATTools.Patterns.Event;

namespace ILYTATTools.Clicker {

    //Base class for all clickable Objects
    public abstract class CO_ClickerObject : ScriptableObject
    {
        public string ClickerName;
        public Sprite ClickerImage;

        [SerializeField]
        internal Event OnClickEvent;

        public void OnClicked(GameObject go)
        {
            OnClickEvent.Occured(go);
        }

        public void Draw(SpriteRenderer rend)
        {
            rend.sprite = ClickerImage;
        }

        public void WriteName(TMProUGUIHandler handler)
        {
            handler.UpdateText(ClickerName);
        }
    }
}