using UnityEngine;
using UnityEngine.InputSystem;

namespace ILYTATTools
{
    public static class MouseHover
    {
        public static GameObject GetHoveredObject { get; private set; }
        public static bool GetIsHovering = false;

        public static void CheckHover()
        {
            Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject go = hit.transform.gameObject;
                if (GetHoveredObject == null)
                {
                    Debug.Log(go.name);
                    Enter(go);
                }
                else if (GetHoveredObject.GetInstanceID() == go.GetInstanceID())
                {
                    Stay(go);
                }
                else
                {
                    EnterNew(go);
                }

                GetIsHovering = true;
                GetHoveredObject = go;
            }
            else if (GetIsHovering)
            {
                Leave(GetHoveredObject);
            }
        }

        private static void Leave(GameObject go)
        {
            // No object hit => Exit last one
            GetIsHovering = false;
            GetHoveredObject = null;
        }

        private static void EnterNew(GameObject go)
        {
            // If new object hit => Exit last + Enter new
            GetIsHovering = true;
        }

        private static void Stay(GameObject go)
        {
            // If hit object is the same as the registered one => Stay
            GetIsHovering = true;

            if (Mouse.current.leftButton.isPressed)
            {
                Debug.Log(go.name + " clicked.");
            }
        }

        private static void Enter(GameObject go)
        {
            GetIsHovering = true;
        }
    }
}