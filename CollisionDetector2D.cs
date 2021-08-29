using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollisionDetector2D : MonoBehaviour
    {
        private bool collisionBegin;
        public bool GetCollisionBegin => collisionBegin;

        private bool collisionStay;
        public bool GetCollisionStay => collisionStay;

        private bool collisionExit;
        public bool GetCollisionExit => collisionExit;

        private GameObject lastCollided;
        private GameObject collidedGO;
        public GameObject GetCollidedObj => collidedGO;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            collisionStay = false;
            collisionExit = false;
            collisionBegin = true;
            collidedGO = collision.gameObject;
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            collisionExit = false;
            collisionBegin = false;
            collisionStay = true;
            collidedGO = collision.gameObject;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            collisionBegin = false;
            collisionStay = false;
            collisionExit = true;
            lastCollided = collision.gameObject;
            collidedGO = null;
            StartCoroutine(ResetExitBool());
        }

        private IEnumerator ResetExitBool()
        {
            yield return new WaitForSeconds(.01f);
            collisionExit = false;
        }

        public GameObject LastCollided()
        {
            GameObject d = null;

            if (lastCollided != null)
            {
                d = lastCollided;
            }
            else if(lastCollided == null && collidedGO != null)
            {
                print("No Last collided object set");
                d = collidedGO;
            }else
            {
                print("No Last collided object set, or current Object.");
                d = transform.parent.gameObject;
            }
            return d;
        }
    }
}