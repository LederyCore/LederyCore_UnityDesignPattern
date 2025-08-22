namespace State 
{
    using System;

    /// <summary>
    /// 상태 머신 클래스입니다.
    /// </summary>
    [Serializable]
    public class StateMachine
    {
        #region Fields
        public IdleState idleState;
        public MoveState moveState;
        public JumpState jumpState;
        #endregion

        #region Properties
        public IState CurrentState { get; private set; }
        #endregion

        #region Constructor
        public StateMachine()
        {
            idleState = new IdleState();
            moveState = new MoveState();
            jumpState = new JumpState();
        }
        #endregion

        #region Methods
        public void Initialize(IState startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }

        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
        #endregion
    }

}