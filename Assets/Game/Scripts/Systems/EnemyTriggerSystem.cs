using Core.Actors;
using Leopotam.Ecs;

namespace Core
{
	public sealed class EnemyTriggerSystem : IEcsRunSystem
	{
		private readonly EcsFilter<OnTriggerEnter> _filter = default;

		private readonly PoolSystem<CubeActor> _pool = default;
		public void Run()
		{
			if (_filter.IsEmpty()) return;

			foreach (var i in _filter)
			{
				var triggerEvent = _filter.Get1(i);

				if (triggerEvent.EntityEnter.IsAlive() && triggerEvent.EntityRequest.IsAlive() && triggerEvent.EntityEnter.Has<PlayerTag>() && triggerEvent.EntityRequest.Has<EnemyTag>())
				{
					var damage = triggerEvent.EntityRequest.Get<Damage>().value;

					triggerEvent.EntityEnter.Get<DamageEvent>().value += damage;

					PoolDict<EnemyData, CubeActor>.Return(triggerEvent.EntityRequest.Get<EnemyDataRef>().value, triggerEvent.EntityRequest.Get<View<CubeActor>>().value);

					triggerEvent.EntityRequest.Destroy();
					_filter.GetEntity(i).Destroy();
				}
			}
		}
	}
}