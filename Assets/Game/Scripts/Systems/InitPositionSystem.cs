using Leopotam.Ecs;

namespace Core
{
	public sealed class InitPositionSystem : IEcsInitSystem
	{
		private readonly EcsFilter<TransformRef> _filter = default;
		public void Init()
		{
			foreach (var i in _filter)
			{
				var transform = _filter.Get1(i).value;
				var entity = _filter.GetEntity(i);
				entity.Get<Position>().value = transform.position;
			}
		}
	}
}