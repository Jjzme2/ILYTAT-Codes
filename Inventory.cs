using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools
{
    public class Inventory : MonoBehaviour
    {
        //Coins
        private int standardCurrency;
        public int getStandardCurrency => standardCurrency;

        //Premium currency
        private int premiumCurrency;
        public int GetPremiumCurrency => premiumCurrency;

        //Items
        private List<GameObject> collectedItems = new List<GameObject>();
        public List<GameObject> GetCollectedItems => collectedItems;

        public void AddCoins(int amountToAdd)
        {
            standardCurrency += amountToAdd;
        }

        public void AddPremiumCurrency(int amountToAdd)
        {
            premiumCurrency += amountToAdd;
        }

        public void AddItem(GameObject go)
        {
            GetCollectedItems.Add(go);
        }
    }
}