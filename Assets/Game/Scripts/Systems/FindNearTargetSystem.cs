using Leopotam.Ecs;
using UnityEngine;

namespace Core
{
	public sealed class FindNearTargetSystem : IEcsRunSystem
	{
		private readonly EcsFilter<PlayerTag, Position, Stats> _filterTarget = default;

		private readonly EcsFilter<EnemyTag, Position> _filterEnemies = default;
		public void Run()
		{
			if (_filterTarget.IsEmpty()) return;

			foreach (var i in _filterTarget)
			{
				var positionPlayer = _filterTarget.Get2(i).value;
				var radius = _filterTarget.Get3(i).value[Const.StateRange].Value; ;

				float distance = Mathf.Infinity;

				Vector2 dir = Vector2.zero;

				foreach (var indexEnemy in _filterEnemies)
				{
					var positionEnemy = _filterEnemies.Get2(indexEnemy).value;

					var direction = (positionEnemy - positionPlayer);

					var dist = direction.sqrMagnitude;

					if (dist > radius * radius)
					{
						continue;
					}

					if (dist < distance)
					{
						distance = dist;
						dir = direction.normalized;
					}
				}

				var entity = _filterTarget.GetEntity(i);
				if (dir != Vector2.zero)
				{
					entity.Get<DirectionAttack>().value = dir;
					continue;
				}

				entity.Del<DirectionAttack>();
			}
		}
	}
}