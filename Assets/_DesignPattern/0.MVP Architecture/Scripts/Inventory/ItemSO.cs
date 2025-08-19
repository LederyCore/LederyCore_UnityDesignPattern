namespace MVP_Architecture
{
    using UnityEngine;
    [CreateAssetMenu(fileName = "Item", menuName = "MVP_Architecture/Item")]
    public class ItemSO : ScriptableObject
    {
        #region Fields
        [SerializeField]
        private string _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _texture;
        [SerializeField]
        private string _description;
        #endregion
    }
}



