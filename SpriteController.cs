using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ILYTATTools.Events;

namespace ILYTATTools
{
    public class SpriteController : MonoBehaviour
    {
        public CollisionDetector2D GetCollisionDetector => GetComponentInChildren<CollisionDetector2D>();
        private SpriteRenderer rend;
        public SpriteRenderer GetRend
        {
            get
            {
                if (rend != null)
                    return rend;
                else
                {
                    if (GetComponent<SpriteRenderer>() != null)
                    {
                        rend = GetComponent<SpriteRenderer>();
                    }
                    else if (GetComponentInChildren<SpriteRenderer>() != null)
                    {
                        rend = GetComponentInChildren<SpriteRenderer>();
                    }
                    else
                    {
                        print("Unable to find a Renderer on this object, or it's children.");
                    }
                    return rend;
                }
            }
        }

        private Animator anim;

        public Animator GetAnim
        {
            get
            {
                if (anim != null)
                    return anim;
                else
                {
                    if (GetComponent<Animator>() != null)
                    {
                        anim = GetComponent<Animator>();
                    }
                    else if (GetComponentInChildren<Animator>() != null)
                    {
                        anim = GetComponentInChildren<Animator>();
                    }
                    else
                    {
                        print("Unable to find an Animator on this object, or it's children.");
                    }
                    return anim;
                }
            }
        }

        public void FlipSpriteHorizontally()
        {
            if (rend.flipX)
            {
                rend.flipX = false;
            }
            else
            {
                rend.flipX = true;
            }
        }

        public void FlipSpriteHorizontally(bool doFlip)
        {
            rend.flipX = doFlip;
        }

        public void FlipSpriteVertically()
        {
            if (rend.flipY)
            {
                rend.flipY = false;
            }
            else
            {
                rend.flipY = true;
            }
        }

        public void ActivateSprite(bool objToo = false)
        {
            if (objToo)
            {
                rend.gameObject.SetActive(true);
            }
            rend.enabled = true;
        }

        public void DeactivateSprite(bool objToo = false)
        {
            if (objToo)
            {
                rend.gameObject.SetActive(false);
            }
            rend.enabled = false;
        }

        private void Awake()
        {
            RunChecks();
        }

        void RunChecks()
        {
            //Run any needed checks here.
            anim = GetAnim;
            rend = GetRend;
        }

        /// <summary>
        /// SafeString enabled* (Run, Attack, Jump Attack, Hurt, Dive, Idle, Defend, Dead)
        /// </summary>
        /// <param name="animToPlay"></param>
        public void PlayAnimation(string animToPlay)
        {
            string a = animToPlay.ToLower();

            if (a == "idle")
                GetAnim.SetBool("IsIdle", true);
            if (a == "run")
                GetAnim.SetBool("IsRunning", true);
            if (a == "defend")
                GetAnim.SetBool("IsDefending", true);
            if (a == "attack")
                GetAnim.SetTrigger("Attack");
            if (a == "dive")
                GetAnim.SetTrigger("Dive");
            if (a == "jump attack" || a == "jumpattack")
                GetAnim.SetTrigger("Jump Attack");
            if (a == "hurt" || a == "hit")
                GetAnim.SetTrigger("Hurt");
            if (a == "dead" || a == "death")
                GetAnim.SetBool("IsDead", true);
        }

        /// <summary>
        /// SafeString enabled* (Run, Idle, Defend, Dead)
        /// </summary>
        /// <param name="animToPlay"></param>
        public void StopAnimation(string animToStop)
        {
            string a = animToStop.ToLower();

            if (a == "idle")
                GetAnim.SetBool("IsIdle", false);
            if (a == "run")
                GetAnim.SetBool("IsRunning", false);
            if (a == "defend")
                GetAnim.SetBool("IsDefending", false);
            if (a == "dead" || a == "death")
                GetAnim.SetBool("IsDead", false);
        }

        public void CheckCollision()
        {
            if (GetCollisionDetector.GetCollisionBegin)
            {
                GameObject hitGO = GetCollisionDetector.GetCollidedObj;
                if (hitGO != null)
                {
                    CollisionEventHandler l = null;
                    //print("Checking if " + hitGO.name + " has a Land Event Handler attached to it.");

                    if (hitGO.GetComponent<CollisionEventHandler>() != null)
                        l = hitGO.GetComponent<CollisionEventHandler>();
                    else if (hitGO.transform.parent != null && hitGO.transform.parent.GetComponent<CollisionEventHandler>() != null)
                        l = hitGO.transform.parent.GetComponent<CollisionEventHandler>();
                    else if (hitGO.GetComponentInChildren<CollisionEventHandler>() != null)
                        l = hitGO.GetComponentInChildren<CollisionEventHandler>();
                    else { print("No Collision Event Handler found on " + hitGO.name + ", its parent, or children."); }

                    if (l != null)
                    {
                        if (l.CollisionToBeginOn == CollisionEventHandler.CollisionType.OnBeginCollision)
                        {
                            l.SetCollidedObject(hitGO);
                            l.CollisionEventStart(gameObject);
                        }
                    }
                }
            }
            else if (GetCollisionDetector.GetCollisionExit)
            {
                GameObject lastHit = GetCollisionDetector.LastCollided();
                CollisionEventHandler l = null;
                //print("Checking if " + lastHit.name + " has a Land Event Handler attached to it.");

                if (lastHit.GetComponent<CollisionEventHandler>() != null)
                    l = lastHit.GetComponent<CollisionEventHandler>();
                else if (lastHit.transform.parent != null && lastHit.transform.parent.GetComponent<CollisionEventHandler>() != null)
                    l = lastHit.transform.parent.GetComponent<CollisionEventHandler>();
                else if (lastHit.GetComponentInChildren<CollisionEventHandler>() != null)
                    l = lastHit.GetComponentInChildren<CollisionEventHandler>();

                if (l != null)
                {
                    if (l.CollisionToBeginOn == CollisionEventHandler.CollisionType.OnExitCollision)
                    {
                        l.SetCollidedObject(lastHit);
                        l.CollisionEventStart(gameObject);
                    }
                }
            }
        }
    }
}