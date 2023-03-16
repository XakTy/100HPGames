using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Core.Actors
{
	public sealed class CubeActor : EntityActor
	{
		public ParticleSystem ParticleDied;
		public Transform Visual;
		protected override void InitComponents()
		{
			Entity.Get<EnemyTag>();
			Entity.Get<View<CubeActor>>().value = this;
			Entity.Get<TransformRef>().value = transform;
			Entity.Get<Visual>().value = Visual;


			if (ParticleDied)
			{
				ParticleDied.transform.SetParent(null);
				Entity.Get<ParticleDied>().value = ParticleDied;
			}
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