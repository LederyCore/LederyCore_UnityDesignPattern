namespace Adapter
{
    using UnityEngine;

    public class NewWeaponSystem : INewWeaponSystem
    {
        private IOldWeaponSystem _oldWeaponSystem;

        public NewWeaponSystem(IOldWeaponSystem oldWeaponSystem)
        {
            _oldWeaponSystem = oldWeaponSystem;
        }

        public void Shoot()
        {
            _oldWeaponSystem.FireWeapon();
            Debug.Log("New weapon fired!");
        }
    }
}
