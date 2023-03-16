using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Core.Actors
{
	public sealed class BulletActor : EntityActor
	{
		public TrailRenderer Trail;
			protected override void InitComponents()
		{
			Entity.Get<BulletTag>();
			Entity.Get<View<BulletActor>>().value = this;
			Entity.Get<TransformRef>().value = transform;
			Entity.Get<Trail>().value = Trail;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent<EntityActor>(out var actor))
			{
				Service<EcsWorld>.Get().NewEntity().Get<OnTriggerEnter>() = new OnTriggerEnter()
				{
					EntityEnter = actor.Entity,
					EntityRequest = Entity
				};
			}
		}
	}
}