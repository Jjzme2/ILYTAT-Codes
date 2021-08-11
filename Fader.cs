using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ILYTATTools
{
    public enum FadeType
    {
        In,
        Out
    }


    public static class Fader
    {
        //TEXT
        public static void Fade(Text textToFade, float fadeTime, FadeType type)
        {
            if (type == FadeType.In)
            {
                //Fade In
                FadeToFullAlpha(textToFade, fadeTime);
            }

            if (type == FadeType.Out)
            {
                //Fade Out
                FadeToZeroAlpha(textToFade, fadeTime);
            }
        }



        private static IEnumerator FadeToFullAlpha(Text t, float FadeDuration)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
            while (t.color.a < 1.0f)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a + (Time.deltaTime / FadeDuration));
                yield return null;
            }
        }

        private static IEnumerator FadeToZeroAlpha(Text t, float FadeDuration)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, 1);
            while (t.color.a > 0.0f)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - (Time.deltaTime / FadeDuration));
                yield return null;
            }
        }














        //Image
        public static void Fade(Image imageToFade, float fadeTime, FadeType type)
        {
            if (type == FadeType.In)
            {
                //Fade In
                FadeToFullAlpha(imageToFade, fadeTime);
            }

            if (type == FadeType.Out)
            {
                //Fade Out
                FadeToZeroAlpha(imageToFade, fadeTime);
            }
        }



        private static IEnumerator FadeToFullAlpha(Image s, float FadeDuration)
        {
            s.color = new Color(s.color.r, s.color.g, s.color.b, 0);
            while (s.color.a < 1.0f)
            {
                s.color = new Color(s.color.r, s.color.g, s.color.b, s.color.a + (Time.deltaTime / FadeDuration));
                yield return null;
            }
        }

        private static IEnumerator FadeToZeroAlpha(Image s, float FadeDuration)
        {
            s.color = new Color(s.color.r, s.color.g, s.color.b, 1);
            while (s.color.a > 0.0f)
            {
                s.color = new Color(s.color.r, s.color.g, s.color.b, s.color.a - (Time.deltaTime / FadeDuration));
                yield return null;
            }
        }









        //TMPRO



        public static void Fade(TextMeshProUGUI textToFade, float fadeTime, FadeType type)
        {
            if (type == FadeType.In)
            {
                //Fade In
                FadeToFullAlpha(textToFade, fadeTime);
            }

            if (type == FadeType.Out)
            {
                //Fade Out
                FadeToZeroAlpha(textToFade, fadeTime);
            }
        }

        private static IEnumerator FadeToFullAlpha(TextMeshProUGUI t, float FadeDuration)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
            while (t.color.a < 1.0f)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a + (Time.deltaTime / FadeDuration));
                yield return null;
            }
        }

        private static IEnumerator FadeToZeroAlpha(TextMeshProUGUI t, float FadeDuration)
        {
            t.color = new Color(t.color.r, t.color.g, t.color.b, 1);
            while (t.color.a > 0.0f)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - (Time.deltaTime / FadeDuration));
                yield return null;
            }
        }


    }
}