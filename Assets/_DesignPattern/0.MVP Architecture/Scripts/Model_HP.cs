
namespace MVP_Architecture
{
    /// <summary>
    /// HP Model in MVP pattern.
    /// Stores and manages HP values and basic operations.
    /// MVP 패턴에서 HP 데이터를 저장하고 기본 연산을 제공하는 Model 클래스.
    /// </summary>
    public class Model_HP
    {
        #region Fields
        private int _maxHP = 100;               // Maximum HP value. (최대 HP 값, 기본 100)
        private int _hp = 50;                   // Current HP value. (현재 HP 값, 초기값 50)
        #endregion

        #region Properties
        /// <summary>
        /// Current HP value. (현재 HP 값)
        /// </summary>
        public int HP => _hp;
        /// <summary>
        /// Maximum HP value. (최대 HP 값)
        /// </summary>
        public int MaxHP => _maxHP;
        #endregion

        #region Methods
        /// <summary>
        /// Increases HP by the given value without clamping.
        /// 주어진 값만큼 HP를 증가. 클램핑 없음.
        /// </summary>
        public void Increment(int value)
        {
            _hp += value;
        }

        /// <summary>
        /// Decreases HP by the given value.
        /// If HP falls below 0, it is reset to 0 (via Reset()).
        /// 주어진 값만큼 HP를 감소.
        /// HP가 0 미만이면 Reset()을 호출해 0으로 초기화.
        /// </summary>
        public void Decrement(int value)
        {
            _hp -= value;
            if (_hp < 0)
            {
                Reset();
            }
        }

        /// <summary>
        /// Resets HP to 0.
        /// HP를 0으로 초기화.
        /// </summary>
        public void Reset()
        {
            _hp = 0;
        }
        #endregion
    }
}
