
namespace Adapter
{
    using UnityEngine;

    /// <summary>
    /// 어댑터 패턴 부트스트래퍼
    /// 어댑터 패턴은 외부 API를 현재 프로젝트에 맞게 변환하거나
    /// 오래된 API를 새로운 API에 맞게 변환하는 데 사용됩니다.
    /// </summary>
    public class AdapterBootstrapper : MonoBehaviour
    {


        #region Methods
        void Awake()
        {
            INewWeaponSystem weapon = new NewWeaponSystem(new OldWeaponSystem());
            weapon.Shoot();
        }
        #endregion
    }
}