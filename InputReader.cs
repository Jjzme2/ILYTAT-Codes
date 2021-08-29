using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Patterns
{
    public class InputReader : MonoBehaviour
    {
        public Vector3 ReadInput()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            if (x != 0 || y != 0)
            {
                Vector3 dir = new Vector3(x, y, 0);
                return dir;
            }
            return Vector3.zero;
        }

        //This will be the control button to perform rewind action.

        internal bool ReadShoot()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}