namespace State
{
    using UnityEngine;

    [DefaultExecutionOrder(-100)] // 다른 스크립트보다 먼저 Ground 체크 실행
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private bool _debugMode = true; // 디버그 모드 활성화 여부
        [SerializeField] private float _groundCheckDistance = 0.2f;
        [SerializeField] private LayerMask _groundLayer = ~0; // 기본값: 모든 레이어
        [SerializeField] private Vector3 _offset = new Vector3(0, 0.1f, 0);

        public bool IsGrounded { get; private set; }

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void CheckGround()
        {
            Vector3 origin = transform.position + _offset;
            Vector3 direction = Vector3.down;

            IsGrounded = Physics.Raycast(origin, direction, _groundCheckDistance, _groundLayer);

            //Scene 뷰 디버그 레이 표시
            if (_debugMode)
            {
                Color rayColor = IsGrounded ? Color.green : Color.red;
                Debug.DrawRay(origin, direction * _groundCheckDistance, rayColor);
            }

        }
    }
}