using UnityEngine.UI;

namespace Core
{
    public class LoseScreen : Screen
    {
        public Button RestartButton;
        private void Start()
        {
            RestartButton.onClick.AddListener(OnNextLevelClick);
        }

        private void OnDestroy()
        {
			RestartButton.onClick.RemoveListener(OnNextLevelClick);
		}

        private void OnNextLevelClick()
        {
            Levels.LoadCurrent();
        }
    }
}