namespace State
{

    public interface IState
    {
        /// <summary>
        /// 상태가 활성화될 때 호출됩니다.
        /// </summary>
        void Enter();

        /// <summary>
        /// 상태가 업데이트될 때 호출됩니다.
        /// </summary>
        void Update();

        /// <summary>
        /// 상태가 비활성화될 때 호출됩니다.
        /// </summary>
        void Exit();
    }
}