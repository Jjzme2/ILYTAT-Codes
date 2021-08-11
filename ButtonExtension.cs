using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ILYTATTools.Extensions
{
    public static class ButtonExtension
    {
        public static void Activate(this UnityEngine.UI.Button original)
        {
            original.interactable = true;
        }

        public static void Deactivate(this UnityEngine.UI.Button original)
        {
            original.interactable = false;
        }

        /// <summary>
        /// Don't forget to use a Lambda or Delegate! *QuickTip(To use a delegate: Delegate{ }
        /// </summary>
        /// <param name="newAction"></param>
        public static void ChangeOnClick(this UnityEngine.UI.Button original, UnityAction newAction)
        {
            original.onClick.AddListener(newAction);
        }

        public static Text GetText(this UnityEngine.UI.Button original)
        {
            if (original.GetComponentInChildren<Text>() == null)
            {
                Debug.LogError("No Text Object found on " + original.name);
                return null;
            }
            else
            {
                return original.GetComponentInChildren<Text>();
            }
        }

        public static Image GetImage(this UnityEngine.UI.Button original)
        {
            if (original.GetComponentInChildren<Image>() == null)
            {
                Debug.LogError("No Text Object found on " + original.name);
                return null;
            }
            else
            {
                return original.GetComponentInChildren<Image>();
            }
        }

        public static void ChangeChildImage(this UnityEngine.UI.Button original, Sprite newImage)
        {
            if (original.GetComponentInChildren<Image>() != null)
            {
                original.GetComponentInChildren<Image>().sprite = newImage;
            }
            return;
        }
    }
}