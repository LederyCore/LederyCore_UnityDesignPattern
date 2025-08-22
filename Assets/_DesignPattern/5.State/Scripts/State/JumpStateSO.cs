namespace State
{
    using UnityEngine;


    [CreateAssetMenu(fileName = "JumpState", menuName = "State/JumpState")]
    public class JumpStateSO : StateSO
    {
        [SerializeField] private float jumpForce = 5f;


        public override void Enter(PlayerStateMachine context)
        {
            base.Enter(context);
            _isRootState = true;
            InitializeSubState();
            Debug.Log("Jump State Entered");
            _context.Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _currentSubState.Enter(_context);
        }

        public override void Update()
        {
            CheckTransition();
        }
        public override void Exit()
        {

        }

        public override void InitializeSubState()
        {
            if (_context.CurrentMovementInput != Vector2.zero)
            {
                SetSubState(_context.States.Get(PlayerStateType.Move));
                Debug.Log("Set Sub State :: Move");
            }
        }
        public override void CheckTransition()
        {
            if (!_context.IsJumpPressed && _context.IsGrounded)
            {
                TransitionToState(_context.States.Get(PlayerStateType.Grounded));
            }
        }

    }
}