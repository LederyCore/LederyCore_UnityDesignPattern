namespace State
{
    using UnityEngine;
    using Utill;

    public class Player : MonoBehaviour
    {
        #region Fields
        private PlayerMoveController _moveController;
        private PlayerInputHandler _inputController;
        #endregion

        #region Methods
        private void Awake()
        {
            _inputController = Utill.GetOrAddComponent<PlayerInputHandler>(gameObject);
            _moveController = Utill.GetOrAddComponent<PlayerMoveController>(gameObject);
        }

        private void OnEnable()
        {
            _inputController.OnMovePerformed += _moveController.OnMovePerformed;
            _inputController.OnMoveCanceled += _moveController.OnMoveCanceled;
            _inputController.OnJumpStarted += _moveController.OnJumpStarted;
        }

        private void OnDisable()
        {
            _inputController.OnMovePerformed -= _moveController.OnMovePerformed;
            _inputController.OnMoveCanceled -= _moveController.OnMoveCanceled;
            _inputController.OnJumpStarted -= _moveController.OnJumpStarted;
        }
        #endregion
    }
}