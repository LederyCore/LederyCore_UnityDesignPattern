namespace Templete_Methods
{

    using Utill;
    public class Sword : Weapon
    {
        #region Methods
        protected override void Fire()
        {
            Utill.Log("검으로 공격");
        }
        #endregion
    }
}