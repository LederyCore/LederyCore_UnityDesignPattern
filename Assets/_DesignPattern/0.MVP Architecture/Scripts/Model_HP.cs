
namespace MVP_Architecture
{
    /// <summary>
    /// HP Model in MVP pattern.
    /// Stores and manages HP values and basic operations.
    /// MVP ���Ͽ��� HP �����͸� �����ϰ� �⺻ ������ �����ϴ� Model Ŭ����.
    /// </summary>
    public class Model_HP
    {
        #region Fields
        private int _maxHP = 100;               // Maximum HP value. (�ִ� HP ��, �⺻ 100)
        private int _hp = 50;                   // Current HP value. (���� HP ��, �ʱⰪ 50)
        #endregion

        #region Properties
        /// <summary>
        /// Current HP value. (���� HP ��)
        /// </summary>
        public int HP => _hp;
        /// <summary>
        /// Maximum HP value. (�ִ� HP ��)
        /// </summary>
        public int MaxHP => _maxHP;
        #endregion

        #region Methods
        /// <summary>
        /// Increases HP by the given value without clamping.
        /// �־��� ����ŭ HP�� ����. Ŭ���� ����.
        /// </summary>
        public void Increment(int value)
        {
            _hp += value;
        }

        /// <summary>
        /// Decreases HP by the given value.
        /// If HP falls below 0, it is reset to 0 (via Reset()).
        /// �־��� ����ŭ HP�� ����.
        /// HP�� 0 �̸��̸� Reset()�� ȣ���� 0���� �ʱ�ȭ.
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
        /// HP�� 0���� �ʱ�ȭ.
        /// </summary>
        public void Reset()
        {
            _hp = 0;
        }
        #endregion
    }
}
