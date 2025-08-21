namespace Singleton
{
    using UnityEngine;


    public class SingletonBootstrapper : MonoBehaviour
    {
        

        private void Awake()
        {
            GameManager.Instance.StartGame();
        }
    }
}