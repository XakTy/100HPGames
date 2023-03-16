using Leopotam.Ecs;
using TMPro;
using UnityEngine.UI;

namespace Core.Actors
{
	public sealed class UpgradeView : EntityActor
	{
		public UpgradeViewRef View;
		protected override void InitComponents()
		{
			Entity.Get<UpgradeViewRef>() = View;
		}

		private void Click()
		{
			Entity.Get<ClickEvent>();
		}
		private void OnEnable()
		{
			View.UpgradeButton.onClick.AddListener(Click);
		}

		private void OnDisable()
		{
			View.UpgradeButton.onClick.RemoveListener(Click);
		}
	}
}