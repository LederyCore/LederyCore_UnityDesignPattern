namespace Templete_Methods
{

    using Utill;
    public class Bow : Weapon
    {
        #region Methods
        protected override void Fire()
        {
            Utill.Log("활로 공격");
        }
        #endregion
    }
}