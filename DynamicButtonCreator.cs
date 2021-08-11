using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;
using TMPro;
using ILYTATTools.Extensions;

namespace ILYTATTools
{
    public class DynamicButtonCreator : MonoBehaviour
    {
        public static DynamicButtonCreator dbc;
        public Transform buttonCreationArea;
        public GameObject ButtonPrefab;

        private List<UnityEngine.UI.Button> CreatedButtonList = new List<UnityEngine.UI.Button>();

        private void Awake()
        {
            if (dbc == null)
            {
                dbc = this;
            }
            else
            {
                Destroy(this);
            }

            if (buttonCreationArea == null)
            {
                Debug.Log("No Button Creation Area is set, automatically setting it to the current object. (" + name + ").");
                buttonCreationArea = this.transform;
            }
        }

        public void AddActiveButton(string textOnButton, Color colorValue, UnityAction buttonAction, string buttonName)
        {
            CreateNewButton(textOnButton, buttonAction, true, buttonName);
        }

        public void CreateNewButton(string newText, UnityAction actionOnClick, bool isActive = true, string buttonName = "New Button")
        {
            GameObject GO = Instantiate(ButtonPrefab, buttonCreationArea);
            GO.name = buttonName;

            UnityEngine.UI.Button b = GO.GetComponent<UnityEngine.UI.Button>();

            if(b == null)
            {
                b = GO.AddComponent<UnityEngine.UI.Button>();
            }

            if (!isActive)
            {
                b.Deactivate();
            }

            Text th = b.GetText();

            if (th != null)
            {
                b.GetText().ChangeText(newText);
            }
            //else if (Ugui != null)
            //{
                //b.GetComponent<TextMeshProUGUI>().ChangeText(newText);
            //}
            else
            {
                Debug.Log("No Text Handler, or TMProUGUI Handler found in (" + name + ")'s children.");
            }
            b.ChangeOnClick(actionOnClick);

            CreatedButtonList.Add(b);
        }

        public UnityEngine.UI.Button GetButtonAtIndex(int indexToFind)
        {
            UnityEngine.UI.Button b = null;

            b = CreatedButtonList[indexToFind];

            return b;
        }

        public UnityEngine.UI.Button GetButtonWithText(string textToFind)
        {
            UnityEngine.UI.Button b = null;

            for (int i = 0; i < CreatedButtonList.Count; i++)
            {
                if (CreatedButtonList[i].GetText().text == textToFind)
                {
                    b = CreatedButtonList[i];
                }
            }

            return b;
        }

        public Button GetButtonWithTMProText(string textToFind)
        {
            Button b = null;

            for (int i = 0; i < CreatedButtonList.Count; i++)
            {
                //if (CreatedButtonList[i].TMProUGUIContoller.GetCurrentText() == textToFind)
                //{
                    //handler = CreatedButtonList[i];
                //}
            }

            return b;
        }
    }
}