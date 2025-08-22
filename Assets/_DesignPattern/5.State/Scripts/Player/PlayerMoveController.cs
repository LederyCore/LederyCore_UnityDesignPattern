namespace State
{
    using UnityEngine;
    using UnityEngine.InputSystem;


    /// <summary>
    /// 플레이어의 이동을 제어하는 컴포넌트입니다.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveController : MonoBehaviour
    {
        #region Fields

        private Rigidbody _rb;
        private Vector2 _moveVector;
        private float _speed = 5f;
        #endregion

        #region Methods

        #region Unity Methods
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 dir = new Vector3(_moveVector.x, 0f, _moveVector.y);
            if (dir.sqrMagnitude > 0.0001f)
            {
                Vector3 next = _rb.position + dir * _speed * Time.fixedDeltaTime;
                _rb.MovePosition(next);
            }
        }

        #endregion

        #region Move
        public void OnMovePerformed(Vector2 vec)
        {
            _moveVector = vec;
        }

        public void OnMoveCanceled()
        {
            _moveVector = Vector2.zero;
        }

        public void OnJumpStarted()
        {
            _rb.AddForce(Vector3.up * 30f, ForceMode.Impulse);
            // 점프 로직을 여기에 추가할 수 있습니다.
            Debug.Log("Jump started");
        }
        #endregion

        #endregion
    }
}