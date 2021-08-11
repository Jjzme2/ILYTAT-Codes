using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ILYTATTools.Extensions
{
    public static class ImageExtension
    {
        public static void FadeImageIn(this Image orig, float fadeTime)
        {
            Fader.Fade(orig, fadeTime, FadeType.In);
        }

        public static void ChangeSprite(this Image orig, Sprite newSprite, float opacity = 1.0f)
        {
            if (orig.color.a != opacity)
            {
                Color c = orig.color;
                orig.color = new Color(c.r, c.g, c.b, opacity);
            }

            orig.sprite = newSprite;
        }

        public static void ResizeImage(this Image orig, float width, float height)
        {
            RectTransform t = orig.GetComponent<RectTransform>();

            t.sizeDelta = new Vector2(width, height);
        }
    }
}