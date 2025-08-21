namespace Strategy
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
        public Action OnAttack;
        public Action OnSwap1;
        public Action OnSwap2;
        public Action OnSwap3;
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
            _actions.Player.Attack.started += RaiseAttack;
            _actions.Player.Swap1.started += RaiseSwap1;
            _actions.Player.Swap2.started += RaiseSwap2;
            _actions.Player.Swap3.started += RaiseSwap3;
            _actions.Player.Enable();
        }

        private void OnDisable()
        {
            _actions.Player.Move.performed -= RaiseMovePerformed;
            _actions.Player.Move.canceled -= RaiseMoveCanceled;
            _actions.Player.Attack.started -= RaiseAttack;
            _actions.Player.Swap1.started -= RaiseSwap1;
            _actions.Player.Swap2.started -= RaiseSwap2;
            _actions.Player.Swap3.started -= RaiseSwap3;
            _actions.Player.Disable();
        }

        private void OnDestroy()
        {
            _actions.Dispose();
        }
        #endregion

        private void RaiseMovePerformed(InputAction.CallbackContext ctx) => OnMovePerformed?.Invoke(ctx);
        private void RaiseMoveCanceled(InputAction.CallbackContext ctx) => OnMoveCanceled?.Invoke(ctx);
        private void RaiseAttack(InputAction.CallbackContext ctx) => OnAttack?.Invoke();
        private void RaiseSwap1(InputAction.CallbackContext ctx) => OnSwap1?.Invoke();
        private void RaiseSwap2(InputAction.CallbackContext ctx) => OnSwap2?.Invoke();
        private void RaiseSwap3(InputAction.CallbackContext ctx) => OnSwap3?.Invoke();

        #endregion
    }
}
