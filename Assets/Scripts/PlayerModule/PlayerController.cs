using CloudeDev.Architecture;
using CloudeDev.Components;
using CloudeDev.InputSystemModule;
using System;
using UnityEngine;

namespace CloudeDev.PlayerModule
{
    [Serializable]
    public sealed class PlayerController : IGameInitListeners, IGameFinishListeners, IGameFixedUpdateListeners
    {
        private InputManager input;
        private CheckSurroundings check;
        private FlipComponent flip;

        [SerializeField]
        private CharacterController controllerPlayer;

        [SerializeField]
        private Transform transform;

        [SerializeField]
        private float speedMoving = 5f;

        [SerializeField]
        private float gravity = -9.81f;

        [SerializeField]
        private float jumpForce = 3;

        private float velocity;

        [Inject]
        public void Construct(InputManager input, CheckSurroundings check, FlipComponent flip)
        {
            this.input = input;
            this.check = check;
            this.flip = flip;
        }

        void IGameInitListeners.OnInitGame()
        {
            input.OnHorizontalDirection += MovingHorizontalDirection;
            input.OnJump += OnJump;
            input.OnAction += OnAction;
            input.OnAttacking += OnAttacking;
            input.OnInventory += OnInventory;
        }

        private void OnJump()
        {
            if (check.IsGrounded())
            {
                velocity = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }

        private void OnInventory()
        {

        }

        private void OnAttacking()
        {

        }

        private void OnAction()
        {

        }

        private void MovingHorizontalDirection(Vector2 direction)
        {
            controllerPlayer.Move(new Vector3(direction.x * speedMoving * Time.deltaTime, 0));
            flip.Reflect(direction.x, transform);
        }

        void IGameFinishListeners.OnFinishGame()
        {
            input.OnHorizontalDirection -= MovingHorizontalDirection;
            input.OnJump -= OnJump;
            input.OnAction -= OnAction;
            input.OnAttacking -= OnAttacking;
            input.OnInventory -= OnInventory;
        }

        private void DoGravity()
        {
            velocity += gravity * Time.fixedDeltaTime;

            controllerPlayer.Move(Vector3.up * velocity * Time.fixedDeltaTime);
        }

        void IGameFixedUpdateListeners.OnFixedUpdate(float FixedDeltaTime)
        {
            DoGravity();

            if (check.IsGrounded() && velocity < 0)
                velocity = -2;
        }
    }
}