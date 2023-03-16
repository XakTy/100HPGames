using Leopotam.Ecs;

namespace Core
{
	public sealed class UpdatePosition : IEcsRunSystem
	{
		private readonly EcsFilter<TransformRef, Position> _filter = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				var transform = _filter.Get1(i).value;
				var position = _filter.Get2(i).value;
				transform.position = position;
			}
		}
	}
}