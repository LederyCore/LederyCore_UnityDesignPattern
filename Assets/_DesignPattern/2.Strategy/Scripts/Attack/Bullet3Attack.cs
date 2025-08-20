namespace Strategy
{

    using Utill;
    public class Bullet3Attack : IAttackStrategy
    {
        #region Fields

        #endregion

        #region Constructor
        public Bullet1Attack()
        {

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