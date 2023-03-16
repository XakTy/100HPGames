using Leopotam.Ecs;

namespace Core
{
	public sealed class UpgradeClickEventSystem : IEcsRunSystem
	{
		private readonly EcsFilter<UpgradeViewRef, Level, UpgradeStateDataRef, ClickEvent> _filter = default;

		private readonly EcsFilter<PlayerTag, Stats> _filterPlayer = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				var entity = _filter.GetEntity(i);
				var data = _filter.Get3(i).value;

				ref var level = ref _filter.Get2(i).value;

				var price = data.StartPrice + data.IncreasePriceLevel * level;

				if (Progress.Money < price)
				{
					entity.Del<ClickEvent>();
					continue;
				}

				Progress.Money -= price;

				var newValue = data.IncreaseValue * (level + 1);

				_filterPlayer.Get2(0).value[data.State.Key].Value += newValue;

				level++;

				Progress.SetLevel(data.State.Key, level);

				entity.Get<UpdateInfo>();
				entity.Del<ClickEvent>();
			}
		}
	}
}