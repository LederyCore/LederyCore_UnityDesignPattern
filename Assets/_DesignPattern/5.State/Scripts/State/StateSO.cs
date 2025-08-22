namespace State
{
    using UnityEngine;

    public abstract class StateSO : ScriptableObject
    {
        protected PlayerStateMachine _context;
        protected bool _isRootState = false;
        protected StateSO _currentSubState;
        private StateSO _currentSuperState;
        

        public virtual void Enter(PlayerStateMachine context)
        {
            _context = context;
        }

        public abstract void Exit();
        public abstract void Update();
        public abstract void CheckTransition();
        public abstract void InitializeSubState();
        public void UpdateStates()
        {
            Update();
            if (_currentSubState != null)
            {
                _currentSubState.UpdateStates();
            }
        }
        public void ExitStates()
        {
            Exit();
            if (_currentSubState != null)
            {
                _currentSubState.ExitStates();
            }
        }
        protected void TransitionToState(StateSO newState)
        {
            Exit();
            newState.Enter(_context);
            if (_isRootState)
            {
                _context.CurrentState = newState;
            }
            else if (_currentSuperState != null)
            {
                _currentSuperState.SetSubState(newState);
            }
        }
        protected void SetSuperState(StateSO newSuperState)
        {
            _currentSuperState = newSuperState;
        }
        protected void SetSubState(StateSO newSubState)
        {
            _currentSubState = newSubState;
            newSubState.SetSuperState(this);
        }
    }
}