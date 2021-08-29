using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Patterns
{
    public class ShootCommand : Command
    {
        public ShootCommand(IEntity entity) : base(entity)
        {

        }

        public override void Execute()
        {
            GameObject go = entity.transform.gameObject;
            //if (entity.transform.GetComponent<ShotPool>().CurrentShotCount < entity.transform.GetComponent<ShotPool>().MaxShots)
            //{
            go.GetComponent<Shooter>().Fire();
            //}
        }
    }
}