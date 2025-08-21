namespace Strategy
{
    using UnityEngine;
    using Utill;
    public class Bullet2Attack : IAttackStrategy
    {
        #region Fields
        private GameObject _bulletPrefab;
        #endregion

        #region Constructor
        public Bullet2Attack(GameObject bulletObject)
        {
            _bulletPrefab = bulletObject;
            Utill.Log("2번 유형의 공격 전략이 생성됨");
        }
        #endregion

        #region Methods
        public void Attack(Transform transform)
        {
            GameObject.Instantiate(_bulletPrefab, transform.position, transform.rotation);
            Utill.Log("2번 유형으로 공격!");
        }
        #endregion
    }
}