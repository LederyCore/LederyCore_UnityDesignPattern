namespace State
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using System;

    /// <summary>
    /// 플레이어 입력을 처리하는 컴포넌트입니다.
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        #region Fields
        private InputSystem_Actions _actions;
        #endregion

        #region Events
        public Action<InputAction.CallbackContext> OnMovePerformed;
        public Action<InputAction.CallbackContext> OnMoveCanceled;
        public Action<InputAction.CallbackContext> OnJumpStarted;
        public Action<InputAction.CallbackContext> OnJumpCanceled;
        public Action<InputAction.CallbackContext> OnAttack;
        public Action<InputAction.CallbackContext> OnSwap1;
        public Action<InputAction.CallbackContext> OnSwap2;
        public Action<InputAction.CallbackContext> OnSwap3;
        #endregion

        #region Methods
        #region Unity Methods
        private void Awake()
        {
            _actions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            _actions.Player.Move.performed += (ctx) => OnMovePerformed?.Invoke(ctx);
            _actions.Player.Move.canceled += (ctx) => OnMoveCanceled?.Invoke(ctx);
            _actions.Player.Jump.started += (ctx) => OnJumpStarted?.Invoke(ctx);
            _actions.Player.Jump.canceled += (ctx) => OnJumpCanceled?.Invoke(ctx);
            _actions.Player.Attack.started += (ctx) => OnAttack?.Invoke(ctx);
            _actions.Player.Swap1.started += (ctx) => OnSwap1?.Invoke(ctx);
            _actions.Player.Swap2.started += (ctx) => OnSwap2?.Invoke(ctx);
            _actions.Player.Swap3.started += (ctx) => OnSwap3?.Invoke(ctx);
            _actions.Player.Enable();
        }

        private void OnDisable()
        {
            _actions.Player.Move.performed -= (ctx) => OnMovePerformed?.Invoke(ctx);
            _actions.Player.Move.canceled -= (ctx) => OnMoveCanceled?.Invoke(ctx);
            _actions.Player.Jump.started -= (ctx) => OnJumpStarted?.Invoke(ctx);
            _actions.Player.Jump.canceled -= (ctx) => OnJumpCanceled?.Invoke(ctx);
            _actions.Player.Attack.started -= (ctx) => OnAttack?.Invoke(ctx);
            _actions.Player.Swap1.started -= (ctx) => OnSwap1?.Invoke(ctx);
            _actions.Player.Swap2.started -= (ctx) => OnSwap2?.Invoke(ctx);
            _actions.Player.Swap3.started -= (ctx) => OnSwap3?.Invoke(ctx);
            _actions.Player.Disable();
        }

        private void OnDestroy()
        {
            _actions.Dispose();
        }
        #endregion
        #endregion
    }
}
