using Leopotam.Ecs;
using UnityEngine;

namespace Core
{
	public sealed class DamageSystem : IEcsRunSystem
	{
		private readonly EcsFilter<Health, Position, DamageEvent> _filter = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				ref var health = ref _filter.Get1(i).value;
				var damage = _filter.Get3(i).value;

				health -= damage;

				var entity = _filter.GetEntity(i);

				if (health <= 0f)
				{
					entity.Get<DiedEvent>();
				}

				var position = _filter.Get2(i).value;

				entity.Get<HitInfo>().value = damage;
				entity.Get<HitInfo>().Position = position;

				entity.Del<DamageEvent>();
			}
		}
	}
}