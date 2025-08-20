namespace Facade
{

    using Utill;
    /// <summary>
    /// 서브 시스템들을 통합하여 클라이언트가 간편하게 사용할 수 있도록 하는 파사드 클래스입니다.
    /// </summary>
    public class PizzaStoreFacade
    {
        #region Fields
        private PizzaBaker _pizzaBaker;
        private PizzaBox _pizzaBox;
        private PizzaTopping _pizzaTopping;
        #endregion

        public PizzaStoreFacade(PizzaBaker pizzaBaker, PizzaBox pizzaBox, PizzaTopping pizzaTopping)
        {
            _pizzaBaker = pizzaBaker;
            _pizzaBox = pizzaBox;
            _pizzaTopping = pizzaTopping;
        }

        public void OrderPizza()
        {
            Utill.Log($"{GetType()}::피자 주문으 들어왔습니다. 조금만 기다려 주세요!");

            _pizzaBaker.OnBakeMachine();
            _pizzaBaker.BakePizza();
            _pizzaTopping.AddCheese();
            _pizzaTopping.AddCheese();
            _pizzaTopping.AddPeperoni();
            _pizzaTopping.AddTomato();
            _pizzaBox.BoxingPizza();
            _pizzaBaker.OffBakeMachine();

            Utill.Log($"{GetType()}::피자 주문이 완료되었습니다. 맛있게 드세요!");
        }
    }
}