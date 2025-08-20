namespace Strategy
{

    using Utill;
    using UnityEngine;
    public class Bullet1Attack : IAttackStrategy
    {
        #region Fields
        private Transform _transform;
        private GameObject _bulletObject;
        #endregion

        #region Constructor
        public Bullet1Attack(Transform transform, GameObject bulletObject)
        {
            _transform = transform;
            _bulletObject = bulletObject;
            Utill.Log("1번 유형의 공격 전략이 생성됨");
        }
        #endregion

        #region Methods
        public void Attack()
        {
            Utill.Log("1번 유형으로 공격!");
        }
        #endregion
    }
}