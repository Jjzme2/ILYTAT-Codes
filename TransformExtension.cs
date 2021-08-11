using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

namespace ILYTATTools.Extensions
{
    public static class TransformExtension
    {
        public static GameObject[] GetChildren(this Transform original)
        {
            List<GameObject> children = new List<GameObject>();
            for (int i = 0; i < original.childCount; i++)
            {
                children.Add(original.GetChild(i).gameObject);
            }

            return children.ToArray();
        }

        public static GameObject InstantiateNewChildObject(this Transform original, GameObject prefab)
        {
            GameObject go =  null;

            go = Object.Instantiate(prefab, original);
            
            return go;
        }

        public static Transform ScaleEvenlyByMultiple(this Transform original, float amountToIncrease)
        {
            float oX = original.localScale.x;
            float oY = original.localScale.y;
            float oZ = original.localScale.z;

            original.localScale = new Vector3(oX * amountToIncrease, oY * amountToIncrease, oZ * amountToIncrease);
            return original;
        }

    }
}