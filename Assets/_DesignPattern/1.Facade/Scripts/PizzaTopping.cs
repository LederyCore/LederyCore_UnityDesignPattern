

namespace Facade
{
    using Utill;
    /// <summary>
    /// 피자에 토핑을 추가 하는 클래스입니다.
    /// </summary>
    public class PizzaTopping
    {
        #region Methods
        public void AddCheese()
        {
            Utill.Log($"{GetType()}::치즈를 추가합니다.");
        }
        public void AddPeperoni()
        {
            Utill.Log($"{GetType()}::페페로니를 추가합니다.");
        }
        public void AddTomato()
        {
            Utill.Log($"{GetType()}::토마토를 추가합니다.");
        }
        #endregion
    }
}