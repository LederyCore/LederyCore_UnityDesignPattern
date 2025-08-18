

namespace MVP_Architecture
{
    using System;
    using System.Collections.Generic;
    [System.Serializable]
    public class InventoryData
    {
        public Dictionary<ItemSO, int> items = new Dictionary<ItemSO, int>();
    }
}