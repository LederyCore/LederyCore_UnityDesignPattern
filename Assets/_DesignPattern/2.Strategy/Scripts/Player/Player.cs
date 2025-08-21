

namespace Strategy
{
    using UnityEngine;

    /// <summary>
    /// 플레이어 캐릭터를 나타내는 컴포넌트입니다.
    /// Facade 패턴을 사용하여 플레이어의 입력, 이동, 공격을 관리합니다.
    /// </summary>
    public class Player : MonoBehaviour
    {
        #region Fields
        private PlayerInputHandler _input;
        private PlayerMoveController _move;
        private PlayerAttackController _attack;
        #endregion


        #region Methods
        private void Awake()
        {
            _input = gameObject.AddComponent<PlayerInputHandler>();
            _move = gameObject.AddComponent<PlayerMoveController>();
            _attack = gameObject.AddComponent<PlayerAttackController>();
        }

        private void OnEnable()
        {
            _input.OnMovePerformed += _move.OnMovePerformed;
            _input.OnMoveCanceled += _move.OnMoveCanceled;
            _input.OnAttack += _attack.OnAttack;
            _input.OnSwap1 += _attack.OnSwap1;
            _input.OnSwap2 += _attack.OnSwap2;
            _input.OnSwap3 += _attack.OnSwap3;
        }

        private void OnDisable()
        {
            _input.OnMovePerformed -= _move.OnMovePerformed;
            _input.OnMoveCanceled -= _move.OnMoveCanceled;
            _input.OnAttack -= _attack.OnAttack;
            _input.OnSwap1 -= _attack.OnSwap1;
            _input.OnSwap2 -= _attack.OnSwap2;
            _input.OnSwap3 -= _attack.OnSwap3;
        }
        #endregion
    }
}