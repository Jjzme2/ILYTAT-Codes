using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Collector
{
    public interface ICollectible
    {
        public GameObject GetGameObject { get; }

        public void Collect(GameObject sender);
    }
}