namespace MVP_Architecture
{
    using UnityEngine;
    using UnityEngine.UI;
    using Utill;
    
    public class View_AddItemButton : View_Base
    {
        #region Fields
        private Button _button;
        #endregion

        #region Methods
        private void Awake()
        {
            _button = gameObject.GetComponent<Button>();
            _button.onClick.AddListener(AddItem);
        }

        public void AddItem()
        {
            Utill.Log("아이템 추가 버튼 클릭");
        }
        #endregion
    }
}

