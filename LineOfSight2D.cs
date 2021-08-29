using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools
{
    [System.Serializable]
    public class Sight
    {
        private GameObject objThatHasSight;
        public GameObject GetSightObject => objThatHasSight;        
        private Vector2 sightDirection;
        public Vector2 GetSightDirection => sightDirection;
        
        private int visibleDistance;
        public int GetVisibleDistance => visibleDistance;
        
        private LayerMask mask;
        public LayerMask GetLayerMask => mask;
        
        private bool canSeeThisDirection;
        public bool GetCanSeeThisDirection => canSeeThisDirection;

        public List<GameObject> SeenObjects { get; private set; }

        public Sight(GameObject obj, Vector2 dir, int dist, LayerMask lm, bool isDirectionallyBlind = false)
        {
            sightDirection = dir;
            objThatHasSight = obj;
            visibleDistance = dist;
            mask = lm;
            canSeeThisDirection = !isDirectionallyBlind;
        }

        private RaycastHit2D[] seenObjs => Physics2D.RaycastAll(new Vector2(GetSightObject.transform.position.x, GetSightObject.transform.position.y),
                                                                    sightDirection, visibleDistance, mask);
        public void See()
        {
            List<GameObject> vObjs = new List<GameObject>();
            if (canSeeThisDirection)
            {
                foreach (RaycastHit2D hit in seenObjs)
                {
                    //if (hit.collider != null)
                    //{
                        vObjs.Add(hit.collider.gameObject);
                    //}
                    //else
                    //{
                    //    Debug.Log("Nothing Hit.")
                    //}
                }
            }
            else
            {
                vObjs.Clear();
            }

            if (vObjs.Contains(objThatHasSight))
            {
                vObjs.Remove(objThatHasSight);
            }
            SeenObjects = vObjs;
        }
    }
    public class LineOfSight2D : MonoBehaviour
    {
        public LayerMask VisibleLayers;

        public Sight UpSight => new Sight(gameObject, Vector2.up, 1, VisibleLayers);
        public Sight DownSight => new Sight(gameObject, Vector2.down, 1, VisibleLayers);
        public Sight LeftSight => new Sight(gameObject, Vector2.left, 1, VisibleLayers);
        public Sight RightSight => new Sight(gameObject, Vector2.right, 1, VisibleLayers);



        private List<GameObject> allVisibleObjects = new List<GameObject>();
        [SerializeField]
        private bool canSeeForward = true;
        [SerializeField]
        private bool canSeeRight = false;
        [SerializeField]
        private bool canSeeDown = false;
        [SerializeField]
        private bool canSeeLeft = false;

        private List<GameObject> GetAllVisibleObjects => allVisibleObjects;

        private void FixedUpdate()
        {
            allVisibleObjects.Clear();
            if (canSeeForward)
                Look(UpSight);
            if (canSeeRight)
                Look(RightSight);
            if (canSeeDown)
                Look(DownSight);
            if (canSeeLeft)
                Look(LeftSight);
        }

        private void Look(Sight sightToSeeWith)
        {
            Debug.DrawRay(transform.position, sightToSeeWith.GetSightDirection, Color.red, 5.0f);
            sightToSeeWith.See();

            if (sightToSeeWith.SeenObjects.Count > 0) 
            {
                foreach (GameObject g in sightToSeeWith.SeenObjects)
                {
                    allVisibleObjects.Add(g);
                    //print("Adding (" + g.name + ") to all visbileObjects");
                }
                //print("All Visible Object Length is " + allVisibleObjects.Count);
            }

        }
    }
}