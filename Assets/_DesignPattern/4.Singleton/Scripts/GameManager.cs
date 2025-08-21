namespace Singleton
{
    using UnityEngine;
    using Utill;

    public class GameManager : MonoBehaviour
    {
        #region Fields
        private static GameManager instance;
        #endregion

        #region Properties
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<GameManager>();
                    if (instance == null)
                    {
                        GameObject singleton = new GameObject("GameManager");
                        instance = singleton.AddComponent<GameManager>();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Methods
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public void StartGame()
        {
            Utill.Log("Game Started");
        }
        #endregion
    }
}