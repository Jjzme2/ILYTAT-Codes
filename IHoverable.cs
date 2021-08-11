using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools
{
    public interface IHoverable
    {
        Vector3 GetPos { get; }
        //new Vector3(MouseHoverToolTip.centeredMousePos.x, MouseHoverToolTip.centeredMousePos.y);

        public void OnHovered(GameObject go);
        //Comment All Ctrl + K + C
        // If no registred hitobject => Entering
        //MouseHoverToolTip.GetTM.text = go.GetComponent<DestinationNodeComponent>().Destination.DestinationName;
        //MouseHoverToolTip.GetTM.enabled = true;
    }
}