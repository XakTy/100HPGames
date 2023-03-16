using Core.Actors;
using Leopotam.Ecs;
using UnityEngine;

namespace Core
{
	public sealed class SpawnerEnemySystem : IEcsRunSystem
	{
		private readonly StaticData _staticData = default;

		private readonly RuntimeData _runtimeData = default;

		private readonly SceneData _sceneData = default;

		private readonly EcsFilter<Spawner>.Exclude<Reload> _filter = default;
		public void Run()
		{
			if (_filter.IsEmpty() || _runtimeData.GameState != GameState.Playing) return;

			foreach (var i in _filter)
			{
				var randIndex = Random.Range(0, _staticData.EntitiesSpawn.Length);

				var enemy = PoolDict<EnemyData, CubeActor>.Get(_staticData.EntitiesSpawn[randIndex], GenerateWorldPositionFromView());

				enemy.gameObject.SetActive(true);

				enemy.Init();
				
				enemy.Entity.Get<Health>().value = _staticData.EntitiesSpawn[randIndex].Health;
				enemy.Entity.Get<Speed>().value = _staticData.EntitiesSpawn[randIndex].Speed;
				enemy.Entity.Get<Damage>().value = _staticData.EntitiesSpawn[randIndex].Damage;
				enemy.Entity.Get<EnemyDataRef>().value = _staticData.EntitiesSpawn[randIndex];
				enemy.Entity.Get<Position>().value = enemy.transform.position;

				var dir = (_sceneData.SpawnPoint.position - enemy.transform.position).normalized;
				enemy.Visual.LookAt(enemy.transform.forward, dir);
				enemy.Entity.Get<DirectionAttack>().value = dir;
				

				_filter.GetEntity(i).Get<Reload>().value = 1f;
			}
		}

		private Vector3 GenerateWorldPositionFromView()
		{
			var pos = Vector3.zero;

			var randInt = Random.Range(0, 2);

			var randPosInt = Random.Range(0, 2);

			var randPosFloat = Random.Range(0f, 1f);

			if (randInt == 0)
			{
				pos = Camera.main.ViewportToWorldPoint(new Vector3(randPosInt, randPosFloat, 0));
			}
			else
			{
				pos = Camera.main.ViewportToWorldPoint(new Vector3(randPosFloat, randPosInt, 0));
			}

			return new Vector3(pos.x * _staticData.Offset.x, pos.y * _staticData.Offset.y);
		}

	}
}