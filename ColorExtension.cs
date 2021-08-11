using UnityEngine;

namespace ILYTATTools.Extensions
{
    public static class ColorExtension
    {
        public static Color ColorizeObject(this GameObject original, Color colorToAssign)
        {
            return original.GetComponent<Renderer>().sharedMaterial.color = colorToAssign;
        }
    }
}