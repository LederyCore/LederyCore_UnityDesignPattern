namespace State
{
    using UnityEngine;


    [CreateAssetMenu(fileName = "IdleState", menuName = "State/IdleState")]
    public class IdleStateSO : StateSO
    {

        public override void Enter(PlayerStateMachine context)
        {
            base.Enter(context);
            Debug.Log("Idle State Entered");
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

        }
        public override void CheckTransition()
        {
            if (_context.CurrentMovementInput != Vector2.zero)
            {
                TransitionToState(_context.States.Get(PlayerStateType.Move));
            }
        }

    }
}