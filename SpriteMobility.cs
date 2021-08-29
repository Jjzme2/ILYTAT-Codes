using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools
{
    public class SpriteMobility : MonoBehaviour
    {
        public MyInput input;
        private Rigidbody2D rb => GetComponentInChildren<Rigidbody2D>();
        private SpriteController controller => GetComponent<SpriteController>();

        [SerializeField]
        private float movementSpeed = 1.5f;

        private bool canMove = true;
        public bool GetCanMove => canMove;

        private void OnEnable()
        {
            if (input == null)
                input = new MyInput();
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }

        private void Update()
        {
            if (canMove)
                if (IsMoving())
                    Move();
        }

        private Vector2 moveDir => input.Movement.Movement.ReadValue<Vector2>();

        private void Move()
        {
            if (moveDir.x > 0)
                controller.FlipSpriteHorizontally(false);
            else if (moveDir.x < 0)
                controller.FlipSpriteHorizontally(true);
            Vector2 currentPos = rb.position;
            Vector2 newPos = currentPos + (moveDir * movementSpeed) * Time.fixedDeltaTime;
            rb.MovePosition(newPos);
            controller.CheckCollision();
        }

        private bool IsMoving()
        {
            if (moveDir.x == 0 && moveDir.y == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetMovementSpeed(float newSpeed)
        {
            movementSpeed = newSpeed;
        }
    }
}