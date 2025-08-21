
namespace Strategy
{
    using UnityEngine;

    /// <summary>
    /// 총알의 이동을 처리하는 컴포넌트입니다.
    /// </summary>
    public class Bullet : MonoBehaviour
    {


        #region Methods
        private void Update()
        {
            // 총알이 발사된 방향으로 이동
            transform.Translate(Vector3.forward * Time.deltaTime * 10f);

            // 일정 시간 후 총알 제거
            Destroy(gameObject, 5f);
        }
        #endregion
    }
}