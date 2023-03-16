using UnityEngine;
using UnityEngine.EventSystems;

namespace Core
{
    public class UI : MonoBehaviour
    {
        public MenuScreen MenuScreen;
        public GameScreen GameScreen;
        public LoseScreen LoseScreen;

        public EventSystem EventSystem;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (!EventSystem.current && EventSystem.current != EventSystem)
            {
                EventSystem.gameObject.SetActive(false);
            }
            else
            {
                EventSystem.gameObject.SetActive(true);
            }
        }

        public void CloseAll()
        {
            MenuScreen.Show(false);
            GameScreen.Show(false);
            LoseScreen.Show(false);
        }
    }
}