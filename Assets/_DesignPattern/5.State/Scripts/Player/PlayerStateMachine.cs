namespace State
{
    using UnityEngine;
    using UnityEngine.InputSystem;
    using Utill;


    /// <summary>
    /// 상태 패턴에서 Context 역할을 하는 클래스입니다.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(GroundChecker))]
    public class PlayerStateMachine : MonoBehaviour
    {
        #region Fields
        [SerializeField] private PlayerStateRegistrySO states;
        [SerializeField] private StateSO initialState;
        private StateSO _currentState;

        private Rigidbody _rigidbody;
        private GroundChecker _groundChecker;

        private Vector2 _currentMovementInput;
        private bool _isJumpPressed;
        private bool _isAttackPressed;
        private bool _isSwap1Pressed;
        private bool _isSwap2Pressed;
        private bool _isSwap3Pressed;
        #endregion

        #region Properties
        public PlayerStateRegistrySO States => states;
        public StateSO CurrentState { get => _currentState; set => _currentState = value; }

        public Rigidbody Rigidbody => _rigidbody;
        public bool IsGrounded => _groundChecker.IsGrounded;

        public Vector2 CurrentMovementInput => _currentMovementInput;
        public bool IsAttackPressed => _isAttackPressed;
        public bool IsSwap1Pressed => _isSwap1Pressed;
        public bool IsSwap2Pressed => _isSwap2Pressed;
        public bool IsSwap3Pressed => _isSwap3Pressed;
        public bool IsJumpPressed => _isJumpPressed;
        #endregion

        #region Methods
        #region Unity Methods
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _groundChecker = Utill.GetOrAddComponent<GroundChecker>(gameObject);
        }
        private void Start()
        {
            _currentState = initialState;
            _currentState.Enter(this);
        }
        private void FixedUpdate()
        {
            _currentState.UpdateStates();
        }
        #endregion
        #region Input Handlers
        public void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            _currentMovementInput = ctx.ReadValue<Vector2>();
        }

        public void OnMoveCanceled(InputAction.CallbackContext ctx)
        {
            _currentMovementInput = Vector2.zero;
        }

        public void OnJumpStarted(InputAction.CallbackContext ctx)
        {
            _isJumpPressed = ctx.ReadValueAsButton();
        }
        public void OnJumpCanceled(InputAction.CallbackContext ctx)
        {
            _isJumpPressed = ctx.ReadValueAsButton();
        }

        public void OnAttack(InputAction.CallbackContext ctx)
        {
            _isAttackPressed = ctx.ReadValueAsButton();
        }

        public void OnSwap1(InputAction.CallbackContext ctx)
        {
            _isSwap1Pressed = ctx.ReadValueAsButton();
        }

        public void OnSwap2(InputAction.CallbackContext ctx)
        {
            _isSwap2Pressed = ctx.ReadValueAsButton();
        }

        public void OnSwap3(InputAction.CallbackContext ctx)
        {
            _isSwap3Pressed = ctx.ReadValueAsButton();
        }
        #endregion
        #endregion
    }
}