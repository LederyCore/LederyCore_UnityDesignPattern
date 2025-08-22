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
        public Action OnJumpStarted;
        #endregion

        #region Methods
        #region Unity Methods
        private void Awake()
        {
            _actions = new InputSystem_Actions();
        }

        private void OnEnable()
        {
            _actions.Player.Move.performed += RaiseMovePerformed;
            _actions.Player.Move.canceled += RaiseMoveCanceled;
            _actions.Player.Jump.started += RaiseJumpStarted;
            _actions.Player.Enable();
        }



        private void OnDisable()
        {
            _actions.Player.Move.performed -= RaiseMovePerformed;
            _actions.Player.Move.canceled -= RaiseMoveCanceled;
            _actions.Player.Jump.started -= RaiseJumpStarted;
            _actions.Player.Disable();
        }

        private void OnDestroy()
        {
            _actions.Dispose();
        }
        #endregion

        private void RaiseMovePerformed(InputAction.CallbackContext ctx) => OnMovePerformed?.Invoke(ctx);
        private void RaiseMoveCanceled(InputAction.CallbackContext ctx) => OnMoveCanceled?.Invoke(ctx);
        private void RaiseJumpStarted(InputAction.CallbackContext ctx) => OnJumpStarted?.Invoke(); 

        #endregion
    }
}
