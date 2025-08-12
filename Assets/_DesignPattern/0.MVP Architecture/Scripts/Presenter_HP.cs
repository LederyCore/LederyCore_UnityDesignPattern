namespace MVP_Architecture
{
    /// <summary>
    /// HP Presenter in MVP pattern.
    /// Mediates between the View and Model for HP-related logic.
    /// MVP 패턴에서 HP 관련 로직을 처리하는 Presenter.
    /// View와 Model 간의 데이터 갱신과 이벤트 전달을 담당.
    /// </summary>
    public class Presenter_HP
    {
        #region Fields
        private readonly IViewHP _view;             // View interface reference (View 인터페이스 참조)
        private readonly Model_HP _model;           // Model instance (Model 인스턴스)
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the Presenter with a View and a Model.
        /// View와 Model을 받아 Presenter를 초기화.
        /// </summary>
        public Presenter_HP(IViewHP view, Model_HP model)
        {
            _view = view;
            _model = model;

            // Immediately synchronize View with Model data.
            // 생성 직후 Model 데이터를 View와 동기화.
            RefreshView();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Handles increment button click event.
        /// HP 증가 버튼 클릭 시 처리 로직.
        /// </summary>
        public void OnIncrementButtonClicked()
        {
            _model.Increment(1);
            RefreshView();
        }

        /// <summary>
        /// Handles decrement button click event.
        /// HP 감소 버튼 클릭 시 처리 로직.
        /// </summary>
        public void OnDecrementButtonClicked()
        {
            _model.Decrement(1);
            RefreshView();
        }

        /// <summary>
        /// Handles reset button click event.
        /// HP 리셋 버튼 클릭 시 처리 로직.
        /// </summary>
        public void OnResetButtonClicked()
        {
            _model.Reset();
            RefreshView();
        }

        /// <summary>
        /// Updates only the HP slider without touching text.
        /// HP 텍스트는 건드리지 않고 슬라이더만 갱신.
        /// </summary>
        public void UpdateHPSlider()
        {
            _view.UpdateHPSlider(CalcNormalizedHP());
        }

        /// <summary>
        /// Updates both HP text and slider to match the Model's state.
        /// Model 상태에 맞춰 HP 텍스트와 슬라이더를 모두 갱신.
        /// </summary>
        private void RefreshView()
        {
            _view.UpdateHPText(_model.HP);
            _view.UpdateHPSlider(CalcNormalizedHP());
        }

        /// <summary>
        /// Calculates HP percentage normalized to 0~1 range.
        /// 0~1 범위의 HP 퍼센트를 계산.
        /// </summary>
        private float CalcNormalizedHP()
        {
            if (_model.MaxHP <= 0) return 0f;
            float n = (float)_model.HP / _model.MaxHP;
            if (n < 0f) n = 0f;
            else if (n > 1f) n = 1f;
            return n;
        }
        #endregion
    }
}