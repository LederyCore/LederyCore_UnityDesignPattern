

namespace Facade
{
    using Utill;
    /// <summary>
    /// 피자를 포장하는 역할을 하는 클래스입니다.
    /// </summary>
    public class PizzaBox
    {
        #region Methods
        public void BoxingPizza()
        {
            Utill.Log($"{GetType()}::피자를 박스에 담습니다.");
        }
        #endregion
    }
}