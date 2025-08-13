namespace MVP_Architecture
{
    public class Presenter_InventoryGrid
    {
        #region Fields
        private readonly IViewInventoryGrid _view; // View interface reference (View 인터페이스 참조)
        private readonly Model_InventoryGrid _model; // Model instance (Model 인스턴스)
        #endregion

        #region Constructor
        public Presenter_InventoryGrid(IViewInventoryGrid view, Model_InventoryGrid model)
        {
            _view = view;
            _model = model;
        }
        #endregion
    }
}