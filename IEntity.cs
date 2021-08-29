using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Patterns
{
    public interface IEntity
    {
        Transform transform { get; }

        void MoveFromTo(Vector3 startPos, Vector3 endPos);
    }
}