using Leopotam.Ecs;

namespace Core
{
	public sealed class DiedParticleSystem : IEcsRunSystem
	{
		private readonly EcsFilter<Position, ParticleDied, DiedEvent> _filter = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				var position = _filter.Get1(i).value;
				var particle = _filter.Get2(i).value;
				particle.transform.position = position;
				particle.gameObject.SetActive(true);
				particle.Play();

			}
		}
	}
}