namespace MVP_Architecture
{
    public class Presenter_Inventory
    {
        #region Fields
        private readonly IViewInventory _view;
        private readonly Model_Inventory _model;
        #endregion

        #region Constructor
        public Presenter_Inventory(IViewInventory view, Model_Inventory model)
        {
            _view = view;
            _model = model;
        }
        #endregion
    }
}