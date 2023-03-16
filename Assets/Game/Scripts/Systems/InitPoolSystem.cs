using Core.Actors;
using Leopotam.Ecs;

namespace Core
{
	public sealed class InitPoolSystem : IEcsInitSystem
	{
		private StaticData _staticData = default;
		public void Init()
		{

			// lazy pool

			PoolDict<EnemyData, CubeActor>.ResetPool();

			foreach (var enemyData in _staticData.EntitiesSpawn)
			{
				PoolDict<EnemyData, CubeActor>.Add(enemyData, enemyData.Prefab, 100, 400);
			}

			PoolDict<SingleEntity, PopUp>.ResetPool();
			PoolDict<SingleEntity, BulletActor>.ResetPool();

			PoolDict<SingleEntity, PopUp>.Add(SingleEntity.PopUp, _staticData.PopUpPrefab, 25, 100);
			PoolDict<SingleEntity, BulletActor>.Add(SingleEntity.Bullet, _staticData.BulletPrefab, 20, 100);
		}
	}
}