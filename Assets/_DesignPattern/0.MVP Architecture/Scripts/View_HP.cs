
namespace MVP_Architecture
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// HP View in MVP pattern.
    /// Handles UI updates for HP value and slider, and sends user interactions to the Presenter.
    /// MVP 패턴에서 HP View 역할을 수행.
    /// HP 값 및 슬라이더 UI 업데이트를 담당하고, 사용자 입력을 Presenter에 전달.
    /// </summary>
    public class View_HP : MonoBehaviour, IViewHP
    {
        #region Fields
        [SerializeField] private TextMeshProUGUI _hpText;       // HP value text (HP 값 표시용 텍스트)
        [SerializeField] private Button _incrementButton;       // Increase HP button (HP 증가 버튼)
        [SerializeField] private Button _decrementButton;       // Decrease HP button (HP 감소 버튼)
        [SerializeField] private Button _resetButton;           // Reset HP button (HP 리셋 버튼)
        [SerializeField] private Slider _hpSlider;              // HP slider (HP 상태 표시 슬라이더)

        private Presenter_HP _presenter;                        // Presenter reference (프리젠터 참조)
        #endregion

        #region Methods
        private void Awake()
        {
            // Create Presenter instance with this View and a new Model.
            // 현재 View와 새 Model을 사용하여 Presenter 인스턴스 생성.
            _presenter = new Presenter_HP(this, new Model_HP());

            // Bind button click events to corresponding Presenter methods.
            // 버튼 클릭 이벤트를 각 Presenter 메서드에 연결.
            _incrementButton.onClick.AddListener(() => _presenter.OnIncrementButtonClicked());
            _decrementButton.onClick.AddListener(() => _presenter.OnDecrementButtonClicked());
            _resetButton.onClick.AddListener(() => _presenter.OnResetButtonClicked());
        }

        /// <summary>
        /// Updates the HP text in the UI.
        /// UI에 HP 텍스트를 갱신.
        /// </summary>
        public void UpdateHPText(int hp)
        {
            if (_hpText != null)
            {
                _hpText.text = $"{hp}";
            }
        }

        /// <summary>
        /// Updates the HP slider value.
        /// HP 슬라이더 값을 갱신.
        /// </summary>
        public void UpdateHPSlider(float hpPercentage)
        {
            if (_hpSlider != null)
            {
                _hpSlider.value = hpPercentage;
            }
        }
        #endregion
    }
}