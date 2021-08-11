using UnityEngine;

namespace ILYTATTools.Extensions
{
    public static class ParticleSystemExtension
    {
        public static void ChangeColorGradientSimple(this ParticleSystem original, Gradient myGradient)
        {
           ParticleSystem.MainModule mainMod =  original.main;
            ParticleSystem.MinMaxGradient g = new ParticleSystem.MinMaxGradient(myGradient);
            mainMod.startColor = g;
        }
    }
}