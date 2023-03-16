using Leopotam.Ecs;
using UnityEngine;
using Core.Actors;
using static UnityEngine.EventSystems.EventTrigger;

namespace Core
{
	public sealed class InitUpgradeSystem : IEcsInitSystem
	{
		private readonly UI _ui = default;

		private readonly StaticData _staticData = default;

		private readonly EcsFilter<Stats> _filterPlayer = default;
		public void Init()
		{
			foreach (var upgrade in _staticData.Upgrades)
			{
				var newUpgrade = Object.Instantiate(_staticData.UpgradePrefab, _ui.GameScreen.Container);
				newUpgrade.Init();
				newUpgrade.Entity.Get<UpgradeStateDataRef>().value = upgrade;

				newUpgrade.View.NameText.text = upgrade.Name;
				newUpgrade.View.PriceText.text = upgrade.StartPrice.ToString();

				ref var level = ref newUpgrade.Entity.Get<Level>().value;
				level = Progress.GetLevel(upgrade.State.Key);


				for (int i = 0; i < level; i++)
				{
					var newValue = upgrade.IncreaseValue * (i + 1);
					_filterPlayer.Get1(0).value[upgrade.State.Key].Value += newValue;
				}


				newUpgrade.Entity.Get<UpdateInfo>();
			}
		}

	}
}