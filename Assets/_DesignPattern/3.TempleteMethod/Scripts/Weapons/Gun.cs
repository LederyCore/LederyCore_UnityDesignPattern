namespace Templete_Methods
{

    using Utill;
    public class Gun : Weapon
    {
        #region Methods
        protected override void Fire()
        {
            Utill.Log("총으로 공격");
        }
        #endregion
    }
}