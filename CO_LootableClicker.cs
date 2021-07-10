using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ILYTATTools.Clicker
{
    [System.Serializable]
    public class ClickerLoot
    {
        [SerializeField]
        int moneyGain;
        public int GetMoneyGain => moneyGain;
        [SerializeField]
        ClickerItem item;
        public ClickerItem GetItem => item;
        [SerializeField]
        int expGain;
        public int GetExpGain => expGain;
    }


    //Another clicker idea: Dialogue
    public abstract class CO_LootableClicker : CO_ClickerObject
    {
        //Clicker Stats
        public int MaxHealth;
        public int MaxTimer;
        public SliderData GetHealthSliderData => SliderData.CreateNewSliderData(MaxHealth);
        public float GetCurrentHealth { get { return GetHealthSliderData.GetCur; } }
        public float GetMaxHealth { get { return GetHealthSliderData.GetMax; } }
        
        //Getter Info
        public TMProUGUIHandler GetHandler { get; private set; }
        public SpriteRenderer GetRend { get; private set; }
        public SliderData GetTimerData => SliderData.CreateNewSliderData(MaxTimer);

        [SerializeField]
        public ClickerLoot cLoot;

        public void Spawn(SpriteRenderer rend, TMProUGUIHandler handler = null)
        {
            //Debug.Log("Spawning " + ClickerName + "Loot attainable: " + cLoot.GetMoneyGain + " coins, and " + cLoot.GetItem.ItemName);        
            //Draw
            GetRend = rend;
            Draw(rend);

            //WriteName if applicable
            if (handler != null)
            {
                GetHandler = handler;
                WriteName(handler);
            }
        }
    }
}