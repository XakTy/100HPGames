using Core.Actors;
using Leopotam.Ecs;
using UnityEngine;

namespace Core
{
	public sealed class SpawnerBulletSystem : IEcsRunSystem
	{
		private readonly EcsFilter<PlayerTag, Stats, Position, DirectionAttack>.Exclude<Reload> _filter = default;

		private readonly StaticData _staticData = default;

		private readonly RuntimeData _runtimeData = default;

		public void Run()
		{
			if (_filter.IsEmpty() || _runtimeData.GameState != GameState.Playing) return;

			foreach (var i in _filter)
			{
				var stats = _filter.Get2(i).value;
				var position = _filter.Get3(i).value;
				var dir = _filter.Get4(i).value;

				var newBullet = PoolDict<SingleEntity, BulletActor>.Get(SingleEntity.Bullet, position);

				newBullet.Init();
				newBullet.Entity.Get<Position>().value = newBullet.Entity.Get<TransformRef>().value.position;
				newBullet.Entity.Get<Damage>().value = stats[Const.StateDamage].Value;
				newBullet.Entity.Get<DirectionAttack>().value = dir;
				newBullet.Entity.Get<Speed>().value = stats[Const.StateSpeed].Value;
				newBullet.Entity.Get<LifeTime>().value = _staticData.LifeTimeBullet;


				var trail = newBullet.Entity.Get<Trail>().value;
				trail.Clear();
				newBullet.gameObject.SetActive(true);

				var entity = _filter.GetEntity(i);


					// don't ask me 
				entity.Get<Reload>().value = 1f - stats[Const.StateReload].Value;
			}
		}
	}
}