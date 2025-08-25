namespace Adapter
{
    using UnityEngine;

    public class OldWeaponSystem : IOldWeaponSystem
    {
        public void FireWeapon()
        {
            Debug.Log("Old weapon fired!");
        }
    }
}