namespace MVP_Architecture
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "ItemDB", menuName = "MVP_Architecture/ItemDB")]
    public class ItemDBSO : ScriptableObject
    {
        #region Fields
        [SerializeField]
        private List<ItemSO> _itemSO = new List<ItemSO>();
        #endregion

        #region Methods
        public IReadOnlyList<ItemSO> GetItems()
        {
            return _itemSO;
        }
        #endregion
    }
}


