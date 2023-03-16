using Leopotam.Ecs;
using UnityEngine;

namespace Core
{
	public struct OnTriggerEnter
	{
		public EcsEntity EntityEnter;
		public EcsEntity EntityRequest;
		public Collider ColliderEnter;
		public Collider ColliderRequest;

	}
}