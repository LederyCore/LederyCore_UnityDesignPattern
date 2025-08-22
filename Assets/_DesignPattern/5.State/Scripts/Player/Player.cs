namespace State
{
    using UnityEngine;
    using Utill;

    public class Player : MonoBehaviour
    {
        #region Fields
        private PlayerInputHandler _inputHandler;
        private PlayerStateMachine _stateMachine;
        #endregion


        #region Methods
        private void Awake()
        {
            _inputHandler = Utill.GetOrAddComponent<PlayerInputHandler>(gameObject);
            _stateMachine = Utill.GetOrAddComponent<PlayerStateMachine>(gameObject);
        }

        private void OnEnable()
        {
            _inputHandler.OnMovePerformed += _stateMachine.OnMovePerformed;
            _inputHandler.OnMoveCanceled += _stateMachine.OnMoveCanceled;
            _inputHandler.OnJumpStarted += _stateMachine.OnJumpStarted;
            _inputHandler.OnJumpCanceled += _stateMachine.OnJumpCanceled;

            _inputHandler.OnAttack += _stateMachine.OnAttack;
            _inputHandler.OnSwap1 += _stateMachine.OnSwap1;
            _inputHandler.OnSwap2 += _stateMachine.OnSwap2;
            _inputHandler.OnSwap3 += _stateMachine.OnSwap3;
        }

        private void OnDisable()
        {
            _inputHandler.OnMovePerformed -= _stateMachine.OnMovePerformed;
            _inputHandler.OnMoveCanceled -= _stateMachine.OnMoveCanceled;
            _inputHandler.OnJumpStarted -= _stateMachine.OnJumpStarted;
            _inputHandler.OnJumpCanceled -= _stateMachine.OnJumpCanceled;

            _inputHandler.OnAttack -= _stateMachine.OnAttack;
            _inputHandler.OnSwap1 -= _stateMachine.OnSwap1;
            _inputHandler.OnSwap2 -= _stateMachine.OnSwap2;
            _inputHandler.OnSwap3 -= _stateMachine.OnSwap3;
        }
        #endregion
    }
}