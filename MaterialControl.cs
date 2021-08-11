using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools
{

    [RequireComponent(typeof(Material))]
    public class MaterialControl : MonoBehaviour
    {

        MeshRenderer myRenderer;



        private void Awake()
        {
            myRenderer = GetComponent<MeshRenderer>();
        }

        public void SetNewMaterial(Material newMat, Color MatColor)
        {
            RenderMaterial(newMat, MatColor);
        }

        private void RenderMaterial(Material toRender, Color toColor)
        {
            myRenderer.material = toRender;
            myRenderer.material.color = toColor;
        }
    }
}