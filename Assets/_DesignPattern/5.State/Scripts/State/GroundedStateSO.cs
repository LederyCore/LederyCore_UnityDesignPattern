namespace State
{
    using UnityEngine;


    [CreateAssetMenu(fileName = "GroundedState", menuName = "State/GroundedState")]
    public class GroundedStateSO : StateSO
    {

        public override void Enter(PlayerStateMachine context)
        {
            base.Enter(context);
            _isRootState = true;
            InitializeSubState();
            Debug.Log("Grounded State Entered");
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
            if (_context.CurrentMovementInput == Vector2.zero)
            {
                SetSubState(_context.States.Get(PlayerStateType.Idle));
                Debug.Log("Set Sub State :: Idle");
            }
            else
            {
                SetSubState(_context.States.Get(PlayerStateType.Move));
                Debug.Log("Set Sub State :: Move");
            }
        }
        public override void CheckTransition()
        {
            if (_context.IsJumpPressed && _context.IsGrounded)
            {
                TransitionToState(_context.States.Get(PlayerStateType.Jump));
            }
        }

    }
}