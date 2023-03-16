using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Core
{
    static partial class Progress
    {
        private static UI _ui;

        public static void SetUI(UI ui)
        {
            _ui = ui;
        }
        public static int Money
	    {
		    get => PlayerPrefs.GetInt("Money", 0);
		    set
            {
	            PlayerPrefs.SetInt("Money", value);
	            _ui.GameScreen.CurrentMoneyText.text = PlayerPrefs.GetInt("Money", 0).ToString();
            }
	    }
		public static int CurrentLevel
        {
            get => PlayerPrefs.GetInt("CurrentLevel", 0);
            set => PlayerPrefs.SetInt("CurrentLevel", value);
        }

		public static int GetLevel(string stateKey)
		{
			return PlayerPrefs.GetInt(stateKey, 0);
		}

		public static void SetLevel(string stateKey, int level)
		{
			PlayerPrefs.SetInt(stateKey, level);
		}
	}
}