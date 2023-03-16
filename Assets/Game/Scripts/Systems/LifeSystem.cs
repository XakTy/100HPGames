using Core.Actors;
using Leopotam.Ecs;

namespace Core
{
	public sealed class LifeSystem : IEcsRunSystem
	{
		private readonly EcsFilter<LifeTime> _filter =default;

		private readonly RuntimeData _runtimeData = default;
		public void Run()
		{
			if (_filter.IsEmpty()) return;

			foreach (var i in _filter)
			{
				ref var lifeTime = ref _filter.Get1(i).value;
				lifeTime -= _runtimeData.deltaTime;

				if (lifeTime <= 0)
				{
					var entity = _filter.GetEntity(i);


					PoolDict<SingleEntity, BulletActor>.Return(
						SingleEntity.Bullet,
						entity.Get<View<BulletActor>>().value
					);


					entity.Destroy();
				}

			}
		}
	}
}