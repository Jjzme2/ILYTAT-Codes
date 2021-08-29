using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Patterns
{
    public class MoveCommand : Command
    {
        private Vector3 dir;

        public MoveCommand(IEntity entity, Vector3 direction) : base(entity)
        {
            dir = direction;
        }

        public override void Execute()
        {
            entity.transform.position += dir * 0.1f;
        }
    }
}