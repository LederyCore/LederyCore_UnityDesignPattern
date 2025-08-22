namespace State
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "State/PlayerStateRegistry")]
    public class PlayerStateRegistrySO : ScriptableObject
    {
        public List<StateEntry> states;

        private Dictionary<PlayerStateType, StateSO> _cache;

        public StateSO Get(PlayerStateType type)
        {
            if (_cache == null)
            {
                _cache = new Dictionary<PlayerStateType, StateSO>();
                foreach (var entry in states)
                    _cache[entry.stateType] = entry.state;
            }
            return _cache[type];
        }
    }

    [System.Serializable]
    public class StateEntry
    {
        public PlayerStateType stateType;
        public StateSO state;
    }

    public enum PlayerStateType 
    { 
      Idle, 
      Move, 
      Grounded,
      Jump,
      Attack,
    }
}