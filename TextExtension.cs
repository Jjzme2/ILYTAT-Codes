using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ILYTATTools.Extensions
{
    public static class TextExtension
    {

        private static bool isTyping;
        public static bool IsTyping => isTyping;

        public static void ClearText(this Text original)
        {
            original.text = "";
        }

        public static void FadeTextIn(this Text original, float fadeTime)
        {
            Fader.Fade(original, fadeTime, FadeType.In);
        }

        public static void FadeTextOut(this Text original, float fadeTime)
        {
            Fader.Fade(original, fadeTime, FadeType.Out);
        }


        public static void ChangeTextColor(this Text original, Color newColor)
        {
            if (newColor.a <= 0)
            {
                Debug.Log("Alpha on color parameter was at 0, setting to 1. If you wish it to be a different number, please make sure to set the appropriate opacity when selecting the color.");
                Color c = new Color(newColor.r, newColor.g, newColor.b, 1);
                newColor = c;
            }
            original.color = newColor;
        }

        private static IEnumerator WriteText(this Text original, string t, float seconds)
        {
            foreach (char c in t)
            {
                original.text += c;
                isTyping = true;
                yield return new WaitForSeconds(seconds);
            }

            isTyping = false;
        }

        public static void ChangeText(this Text original, string newText, float timeToWrite = 0.0f)
        {
            if (!isTyping)
            {
                ClearText(original);

                original.StartCoroutine(WriteText(original, newText, timeToWrite));
            }
            else
            {
                Debug.Log("Please wait until text is finished before trying to change the text.");
            }
        }

        public static void ChangeInactiveText(this Text original, string newText)
        {
            original.text = newText;
        }
    }
}