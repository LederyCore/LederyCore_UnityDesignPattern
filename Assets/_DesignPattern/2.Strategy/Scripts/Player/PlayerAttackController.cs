

namespace Strategy
{
    using UnityEngine;

    /// <summary>
    /// 플레이어의 공격을 제어하는 컴포넌트입니다.
    /// </summary>
    public class PlayerAttackController : MonoBehaviour
    {
        #region Fields
        private IAttackStrategy _attackStrategy;
        private GameObject _currentBullet;
        private GameObject[] _bulletPrefab = new GameObject[3];
        #endregion

        #region Methods
        #region Unity Methods
        private void Awake()
        {
            _bulletPrefab[0] = Resources.Load<GameObject>("Prefab/2.Strategy/Bullet1");
            _bulletPrefab[1] = Resources.Load<GameObject>("Prefab/2.Strategy/Bullet2");
            _bulletPrefab[2] = Resources.Load<GameObject>("Prefab/2.Strategy/Bullet3");
            OnSwap1(); // 기본적으로 Bullet1Attack 사용
        }
        #endregion
        public void OnAttack()
        {
            _attackStrategy.Attack(transform);
        }

        public void OnSwap1()
        {
            _currentBullet = _bulletPrefab[0];
            _attackStrategy = new Bullet1Attack(_currentBullet);
        }

        public void OnSwap2()
        {
            _currentBullet = _bulletPrefab[1];
            _attackStrategy = new Bullet2Attack(_currentBullet);
        }

        public void OnSwap3()
        {
            _currentBullet = _bulletPrefab[2];
            _attackStrategy = new Bullet3Attack(_currentBullet);
        }
        #endregion
    }
}