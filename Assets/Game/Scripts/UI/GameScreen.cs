using TMPro;
using UnityEngine;

namespace Core
{
    public class GameScreen : Screen
    {
        public TextMeshProUGUI CurrentMoneyText;
        public RectTransform Container;

        public void OnDisable()
        {
	        if (Container.childCount == 0) return;

	        foreach (RectTransform o in Container)
	        {
		        Object.Destroy(o.gameObject);
	        }
        }
    }
}