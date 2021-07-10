using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Clicker {
    public class LootableSelector : MonoBehaviour
    {
        public List<CO_LootableClicker> Lootables = new List<CO_LootableClicker>();

        public CO_LootableClicker SearchByName(string nameToFind)
        {
            CO_LootableClicker clickerToFind = null;

            foreach(CO_LootableClicker c in Lootables)
            {
                if(c.ClickerName == nameToFind)
                {
                    clickerToFind = c;
                }
            }

            if(clickerToFind != null)
            {
                return clickerToFind;
            }
            else
            {
                Debug.Log("Unable to find a lootable Object named (" + nameToFind + ")");
                return null;
            }
        }


        public CO_LootableClicker SearchByIndex(int indexToFind)
        {
            CO_LootableClicker clickerToFind = Lootables[indexToFind];

            if (clickerToFind != null)
            {
                return clickerToFind;
            }
            else
            {
                Debug.Log("Unable to find a lootable Object at index (" + indexToFind + "). Returning at 0.");
                clickerToFind = Lootables[0];

                if (clickerToFind == null)
                {
                    Debug.Log("Unable to find a lootable Object at any index. Returning null.");
                    return null;
                }
                return clickerToFind;
            }
        }

        public CO_LootableClicker GetRandomSelection
        {
            get
            {
                CO_LootableClicker c = null;

                int ran = Random.Range(0, Lootables.Count);
                c = Lootables[ran];

                if(c == null)
                {
                    c = Lootables[0];
                    if(c == null)
                    {
                        Debug.Log("No Lootable Objects defined in " + name);
                    }
                }
                return c;
            }
        }
    }
}