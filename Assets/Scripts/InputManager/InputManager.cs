using CloudeDev.Architecture;
using System;
using UnityEngine;

namespace CloudeDev.InputSystemModule
{
    [Serializable]
    public class InputManager : IGameUpdateListeners, IGameFinishListeners, IGameInitListeners
    {
        public event Action OnAttacking;
        public event Action OnAction;
        public event Action OnInventory;
        public event Action OnJump;
        public event Action<Vector2> OnHorizontalDirection;

        private InputActionClass actions;

        void IGameUpdateListeners.OnUpdate(float deltaTime)
        {
            InputHandler();
        }

        private void InputHandler()
        {
            var inputDirection =  actions.GamePlay.HorizontalMoving.ReadValue<Vector2>();
            OnHorizontalDirection?.Invoke(inputDirection);
        }

        void IGameInitListeners.OnInitGame()
        {
            actions = new InputActionClass();
            actions.Enable();

            actions.GamePlay.Jump.performed += Jump_performed;
            actions.GamePlay.Attack.performed += Attack_performed;
            actions.GamePlay.Action.performed += Action_performed;
            actions.GamePlay.Inventory.performed += Inventory_performed;
          
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        private void Inventory_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnInventory?.Invoke();
        }

        private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnAction?.Invoke();
        }

        private void Attack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnAttacking?.Invoke();
        }

        void IGameFinishListeners.OnFinishGame()
        {
            actions.GamePlay.Attack.performed -= Attack_performed;
            actions.GamePlay.Action.performed -= Action_performed;
            actions.GamePlay.Inventory.performed -= Inventory_performed;
        }
    }
}
