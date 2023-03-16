using System;
using TMPro;
using UnityEngine.UI;

namespace Core
{
	[Serializable]
	public struct UpgradeViewRef
	{
		public Button UpgradeButton;
		public TMP_Text NameText;
		public TMP_Text PriceText;
	}
}