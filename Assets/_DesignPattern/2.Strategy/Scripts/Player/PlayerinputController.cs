namespace Strategy
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using System;
    using Utill;

    /// <summary>
    /// 플레이어 입력을 처리하는 컴포넌트입니다.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerInputController : MonoBehaviour
    {
        #region Fields
        private Rigidbody _rb;
        private InputSystem_Actions _actions;
        private Vector2 _moveVector;
        private float _speed = 5f;
        private IAttackStrategy _attackStrategy;

        private Action<InputAction.CallbackContext> _onMovePerformed;
        private Action<InputAction.CallbackContext> _onMoveCanceled;
        private Action<InputAction.CallbackContext> _onAttack;
        private Action<InputAction.CallbackContext> _onSwap1;
        private Action<InputAction.CallbackContext> _onSwap2;
        private Action<InputAction.CallbackContext> _onSwap3;
        #endregion

        #region Methods

        #region Unity Methods
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _actions = new InputSystem_Actions();
            _onMovePerformed = OnMovePerformed;
            _onMoveCanceled = OnMoveCanceled;
            _onAttack = OnAttack;
            _onSwap1 = OnSwap1;
            _onSwap2 = OnSwap2;
            _onSwap3 = OnSwap3;

            _attackStrategy = new 
        }

        private void OnEnable()
        {
            _actions.Player.Move.performed += _onMovePerformed;
            _actions.Player.Move.canceled += _onMoveCanceled;
            _actions.Player.Attack.started += _onAttack;
            _actions.Player.Swap1.started += _onSwap1;
            _actions.Player.Swap2.started += _onSwap2;
            _actions.Player.Swap3.started += _onSwap3;
            _actions.Player.Enable();
        }

        private void OnDisable()
        {
            _actions.Player.Move.performed -= _onMovePerformed;
            _actions.Player.Move.canceled -= _onMoveCanceled;
            _actions.Player.Attack.started -= _onAttack;
            _actions.Player.Swap1.started -= _onSwap1;
            _actions.Player.Swap2.started -= _onSwap2;
            _actions.Player.Swap3.started -= _onSwap3;
            _actions.Player.Disable();
        }

        private void OnDestroy()
        {
            _actions.Dispose();
        }

        private void FixedUpdate() // 물리는 FixedUpdate에서
        {
            Vector3 dir = new Vector3(_moveVector.x, 0f, _moveVector.y);
            if (dir.sqrMagnitude > 0.0001f)
            {
                Vector3 next = _rb.position + dir * _speed * Time.fixedDeltaTime;
                _rb.MovePosition(next);
            }
        }
        #endregion

        #region Move
        private void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            _moveVector = ctx.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext ctx)
        {
            _moveVector = Vector2.zero;
        }
        #endregion

        #region Attack
        private void OnAttack(InputAction.CallbackContext ctx)
        {
            _attackStrategy.Attack();
        }

        private void OnSwap1(InputAction.CallbackContext context)
        {
            _attackStrategy = new Bullet1Attack();
        }

        private void OnSwap2(InputAction.CallbackContext context)
        {
            _attackStrategy = new Bullet2Attack();
        }

        private void OnSwap3(InputAction.CallbackContext context)
        {
            _attackStrategy = new Bullet3Attack();
        }
        #endregion
        #endregion
    }
}
