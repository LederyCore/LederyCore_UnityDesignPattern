namespace Strategy
{

    using Utill;
    using UnityEngine;
    public class Bullet1Attack : IAttackStrategy
    {
        #region Fields
        private GameObject _bulletPrefab;
        #endregion

        #region Constructor
        public Bullet1Attack(GameObject bulletPrefab)
        {
            _bulletPrefab = bulletPrefab;
            Utill.Log("1번 유형의 공격 전략이 생성됨");
        }
        #endregion

        #region Methods
        public void Attack(Transform transform)
        {
            GameObject.Instantiate(_bulletPrefab, transform.position, transform.rotation);
            Utill.Log("1번 유형으로 공격!");
        }
        #endregion
    }
}