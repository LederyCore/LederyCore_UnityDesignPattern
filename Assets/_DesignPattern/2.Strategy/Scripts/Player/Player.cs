

namespace Strategy
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        #region Fields
        PlayerInputController _playerInputController;
        #endregion


        #region Methods
        private void Awake()
        {
            _playerInputController = gameObject.AddComponent<PlayerInputController>();
        }
        #endregion
    }
}