
namespace Facade
{
    using UnityEngine;
    /// <summary>
    /// Facade ������ �׽�Ʈ �ϱ� ���� Ŭ���̾�Ʈ ������ �ϴ� ��Ʈ��Ʈ���� Ŭ�����Դϴ�.
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