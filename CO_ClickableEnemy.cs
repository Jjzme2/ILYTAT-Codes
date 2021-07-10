using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = ILYTATTools.Patterns.Event;


namespace ILYTATTools.Clicker
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Custom/Clicker/Clickable Objects/Lootable/Enemy")]
    public class CO_ClickableEnemy : CO_LootableClicker
    {
        public int damage;
        //public Stats myStats; Maybe implement?
    }
}