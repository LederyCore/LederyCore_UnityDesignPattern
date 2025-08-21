namespace Templete_Methods 
{
    using UnityEngine;

    public class TempleteMethodBootstrapper : MonoBehaviour
    {
        #region Methods
        private void Start()
        {
            // 무기 생성
            Weapon bow = new Bow();
            Weapon gun = new Gun();
            Weapon sword = new Sword();

            // 무기로 공격
            bow.Attack();
            gun.Attack();
            sword.Attack();
        }
        #endregion
    }
}