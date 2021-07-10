using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ILYTATTools.Clicker
{
    public abstract class ClickerItem : ScriptableObject
    {
        public string ItemName;
        public Sprite ItemImage;
        public Quality GetItemQuality => Quality.GetRandomQuality();

        public void Draw(SpriteRenderer rend, SpriteRenderer border = null)
        {
            if(border != null)
            {
                border.color = GetItemQuality.QualityColor;
            }

            rend.sprite = ItemImage;
        }

        public void WriteName(TMProUGUIHandler handler)
        {
            handler.UpdateText(ItemName);
        }

        public abstract void Use();
    }
}
