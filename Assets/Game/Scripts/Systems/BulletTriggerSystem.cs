using Core.Actors;
using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Core
{
	public sealed class BulletTriggerSystem : IEcsRunSystem
	{
		private readonly EcsFilter<OnTriggerEnter> _filter = default;
		private readonly SceneData _sceneData = default;
		public void Run()
		{
			if (_filter.IsEmpty()) return;

			foreach (var i in _filter)
			{
				var triggerEvent = _filter.Get1(i);

				if (triggerEvent.EntityEnter.IsAlive() && triggerEvent.EntityRequest.IsAlive() && triggerEvent.EntityEnter.Has<EnemyTag>() && triggerEvent.EntityRequest.Has<BulletTag>())
				{
					var damage = triggerEvent.EntityRequest.Get<Damage>().value;

					triggerEvent.EntityEnter.Get<DamageEvent>().value += damage;

					triggerEvent.EntityEnter.Get<TransformRef>().value.DOKill();
					triggerEvent.EntityEnter.Get<TransformRef>().value.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f);

					PoolDict<SingleEntity, BulletActor>.Return(
						SingleEntity.Bullet, 
						triggerEvent.EntityRequest.Get<View<BulletActor>>().value
					);


					triggerEvent.EntityRequest.Destroy();

					_filter.GetEntity(i).Destroy();
				}
			}
		}
	}
}