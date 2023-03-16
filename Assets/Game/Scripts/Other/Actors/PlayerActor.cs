using Leopotam.Ecs;
using UnityEngine;

namespace Core.Actors
{
	public sealed class PlayerActor : EntityActor
	{
		public Transform View;
		public ParticleSystem ParticleDied;
		protected override void InitComponents()
		{
			Entity.Get<PlayerTag>();
			Entity.Get<ViewRange>().value = View;
			Entity.Get<TransformRef>().value = transform;
			Entity.Get<ParticleDied>().value = ParticleDied;
		}
	}
}