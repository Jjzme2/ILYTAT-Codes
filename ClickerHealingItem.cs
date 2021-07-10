using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ILYTATTools.Clicker
{
    [CreateAssetMenu(fileName = "New Healing Item", menuName = "Custom/Clicker/Item")]
    public class ClickerHealingItem : ClickerItem
    {
        public int AmountToHeal;

        //Parameter target?
        public override void Use()
        {
            Debug.Log("Using Healing Item. (" + ItemName + "/ Heal amount " + AmountToHeal);
        }
    }
}