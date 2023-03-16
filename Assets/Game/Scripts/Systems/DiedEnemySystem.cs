using Core.Actors;
using Leopotam.Ecs;

namespace Core
{
	public sealed class DiedEnemySystem : IEcsRunSystem
	{
		private readonly EcsFilter<EnemyTag, EnemyDataRef, DiedEvent> _filter = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				var entity = _filter.GetEntity(i);
				var data = _filter.Get2(i).value;

				PoolDict<EnemyData, CubeActor>.Return(data, entity.Get<View<CubeActor>>().value);

				entity.Destroy();

				Progress.Money += data.BasicGold;
			}
		}
	}
}