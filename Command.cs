using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Patterns
{
    public abstract class Command
    {
        protected IEntity entity;

        public Command(IEntity e)
        {
            entity = e;
        }

        public abstract void Execute();
    }
}