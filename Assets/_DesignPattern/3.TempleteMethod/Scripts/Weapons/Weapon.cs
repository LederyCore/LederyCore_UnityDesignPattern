namespace Templete_Methods
{
    using UnityEngine;
    using Utill;

    /// <summary>
    /// 템플릿 메서드를 적용한 무기 클래스입니다.
    /// 전략 패턴과 연계할 수도 있습니다.
    /// </summary>
    public abstract class Weapon
    {

        #region Methods
        /// <summary>
        /// 템플릿 메소드 패턴의 기본 구조를 정의합니다.
        /// </summary>
        public void Attack()
        {
            Aim(); // 조준 단계
            Fire(); // 무기별로 구현된 공격 단계
            AfterFire(); // 공격 후 딜레이 단계
        }

        protected virtual void Aim()
        {
            Utill.Log("기본 조준");
        }

        protected abstract void Fire(); // 무기에 따라 달라지는 구현을 강제합니다.

        protected virtual void AfterFire()
        {
            Utill.Log("공격 후 딜레이");
        }
        #endregion
    }
}