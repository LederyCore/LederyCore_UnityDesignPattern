
namespace Facade
{
    using UnityEngine;
    /// <summary>
    /// Facade 패턴을 테스트 하기 위해 클라이언트 역할을 하는 부트스트래퍼 클래스입니다.
    /// </summary>
    public class FacadeBootstrapper : MonoBehaviour
    {
        #region Fields

        #endregion



        #region Methods
        private void Awake()
        {
            PizzaBaker pizzaBaker = new PizzaBaker();
            PizzaBox pizzaBox = new PizzaBox();
            PizzaTopping pizzaTopping = new PizzaTopping();

            PizzaStoreFacade pizzaStore = new PizzaStoreFacade(pizzaBaker, pizzaBox, pizzaTopping);
            pizzaStore.OrderPizza();
        }
        #endregion
    }
}