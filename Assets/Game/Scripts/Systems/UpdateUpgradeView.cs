using Leopotam.Ecs;

namespace Core
{
	public sealed class UpdateUpgradeView : IEcsRunSystem
	{
		private readonly EcsFilter<UpgradeViewRef, Level, UpgradeStateDataRef, UpdateInfo> _filter = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				var entity = _filter.GetEntity(i);
				var upgradeView = _filter.Get1(i);
				var data = _filter.Get3(i).value;

				var level =  _filter.Get2(i).value;
				if (level + 1 > data.Maxlevel)
				{
					upgradeView.UpgradeButton.interactable = false;
					upgradeView.UpgradeButton.onClick.RemoveAllListeners();
					upgradeView.PriceText.text = Const.MAX;
					entity.Destroy();
					continue;
				}

				upgradeView.PriceText.text = (data.StartPrice + data.IncreasePriceLevel * level).ToString();
			}
		}
	}
}