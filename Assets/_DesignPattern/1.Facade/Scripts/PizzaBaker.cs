

namespace Facade
{
    using Utill;
    /// <summary>
    /// 피자를 굽는 역할을 하는 클래스입니다.
    /// </summary>
    public class PizzaBaker
    {
        #region Methods
        public void OnBakeMachine()
        {
            Utill.Log($"{GetType()}::피자 굽는 기계를 켭니다.");
        }


        public void BakePizza()
        {
            Utill.Log($"{GetType()}::피자를 굽습니다.");
        }

        public void OffBakeMachine()
        {
            Utill.Log($"{GetType()}::피자 굽는 기계를 끕니다.");
        }

        #endregion
    }
}