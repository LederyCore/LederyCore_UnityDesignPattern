namespace MVP_Architecture
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>
    /// 인벤토리 UI의 View 계층 클래스입니다.  
    /// Handles drag-and-drop and click toggle for the inventory panel in MVP architecture.
    /// - Implements IViewInventory to connect with the presenter.  
    /// - Supports smooth drag movement with pointer offset to prevent snapping.  
    /// - Restricts movement within parent bounds using ClampToParent.
    /// </summary>
    public class View_Inventory : View_Base, IViewInventory,
        IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region Fields
        [SerializeField] private View_InventoryGrid[] _inventoryGrid;
        [SerializeField] private GameObject _contentPanel;

        private Presenter_Inventory _presenter;

        private RectTransform _rect;
        private RectTransform _parentRect;
        private Canvas _canvas;
        private CanvasGroup _cg;
        private Vector2 _pointerOffsetLocal;
        #endregion

        #region Methods
        private void Awake()
        {
            _presenter = new Presenter_Inventory(this, new Model_Inventory());

            _rect = (RectTransform)transform;
            _parentRect = _rect.parent as RectTransform;
            _canvas = GetComponentInParent<Canvas>();
            _cg = GetComponent<CanvasGroup>();
            if (_cg == null)
                _cg = gameObject.AddComponent<CanvasGroup>();
        }

        /// <summary>
        /// 인벤토리 영역 클릭 시 콘텐츠 패널을 토글합니다.  
        /// Toggles the content panel on inventory click.
        /// </summary>
        /// <param name="eventData">클릭 이벤트 데이터 / Pointer event data.</param>
        public void OnPointerClick(PointerEventData eventData)
        {
            _contentPanel.SetActive(!_contentPanel.activeSelf);
        }

        /// <summary>
        /// 드래그 시작 시 포인터와 오브젝트 사이의 오프셋을 계산하고 Raycast를 비활성화합니다.  
        /// Calculates pointer offset and disables raycast blocking at the start of drag.
        /// </summary>
        /// <param name="eventData">드래그 시작 이벤트 데이터 / Pointer event data at drag start.</param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            _cg.blocksRaycasts = false;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _parentRect, eventData.position, GetEventCamera(), out var pointerLocal))
            {
                _pointerOffsetLocal = pointerLocal - _rect.anchoredPosition;
            }
        }

        /// <summary>
        /// 드래그 중 인벤토리 패널의 위치를 업데이트합니다.  
        /// Updates the inventory panel position while dragging.
        /// </summary>
        /// <param name="eventData">드래그 이벤트 데이터 / Pointer event data during drag.</param>
        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _parentRect, eventData.position, GetEventCamera(), out var pointerLocal))
            {
                var target = pointerLocal - _pointerOffsetLocal;
                target = ClampToParent(target, _rect, _parentRect);
                _rect.anchoredPosition = target;
            }
        }

        /// <summary>
        /// 드래그 종료 시 Raycast 차단을 다시 활성화합니다.  
        /// Re-enables raycast blocking after drag ends.
        /// </summary>
        /// <param name="eventData">드래그 종료 이벤트 데이터 / Pointer event data at drag end.</param>
        public void OnEndDrag(PointerEventData eventData)
        {
            _cg.blocksRaycasts = true;
        }
        #endregion

        #region Helper
        private Camera GetEventCamera()
        {
            if (_canvas == null) return null;
            return _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _canvas.worldCamera;
        }

        private static Vector2 ClampToParent(Vector2 targetAnchoredPos, RectTransform rect, RectTransform parent)
        {
            var parentRect = parent.rect;
            var size = rect.rect.size;

            float left = -parentRect.width * parent.pivot.x + size.x * rect.pivot.x;
            float right = parentRect.width * (1 - parent.pivot.x) - size.x * (1 - rect.pivot.x);
            float bottom = -parentRect.height * parent.pivot.y + size.y * rect.pivot.y;
            float top = parentRect.height * (1 - parent.pivot.y) - size.y * (1 - rect.pivot.y);

            targetAnchoredPos.x = Mathf.Clamp(targetAnchoredPos.x, left, right);
            targetAnchoredPos.y = Mathf.Clamp(targetAnchoredPos.y, bottom, top);
            return targetAnchoredPos;
        }
        #endregion
    }
}
