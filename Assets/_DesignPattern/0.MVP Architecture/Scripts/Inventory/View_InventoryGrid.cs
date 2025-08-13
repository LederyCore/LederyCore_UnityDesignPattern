using UnityEngine.EventSystems;

namespace MVP_Architecture
{
    public class View_InventoryGrid : View_Base, IViewInventoryGrid, IPointerClickHandler, IDragHandler
    {

        #region Fields


        private Presenter_InventoryGrid _presenter;


        #endregion

        #region Methods
        private void Awake()
        {
            _presenter = new Presenter_InventoryGrid(this, new Model_InventoryGrid());
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Utill.Utill.Log($"{gameObject.name}::그리드 클릭됨!");
        }

        public void OnDrag(PointerEventData eventData)
        {

        }
        #endregion
    }
}