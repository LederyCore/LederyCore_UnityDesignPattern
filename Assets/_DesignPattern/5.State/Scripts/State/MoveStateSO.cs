namespace State
{
    using UnityEngine;


    [CreateAssetMenu(fileName = "MoveState", menuName = "State/MoveState")]
    public class MoveStateSO : StateSO
    {
        [SerializeField] private float _speed = 5f;

        public override void Enter(PlayerStateMachine context)
        {
            base.Enter(context);

            Debug.Log("Move State Entered");
        }

        public override void Update()
        {
            var _rb = _context.Rigidbody;
            Vector3 dir = new Vector3(_context.CurrentMovementInput.x, 0f, _context.CurrentMovementInput.y);
            if (dir.sqrMagnitude > 0.0001f)
            {
                Vector3 next = _rb.position + dir * _speed * Time.fixedDeltaTime;
                _rb.MovePosition(next);
            }
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
            if (_context.CurrentMovementInput == Vector2.zero)
            {
                TransitionToState(_context.States.Get(PlayerStateType.Idle));
            }
        }

    }
}