using Leopotam.Ecs;

namespace Core
{
	public sealed class MoveSystem : IEcsRunSystem
	{
		private readonly EcsFilter<Position, Speed, DirectionAttack> _filter = default;

		private readonly RuntimeData _runtimeData = default;
		public void Run()
		{
			if (_runtimeData.GameState != GameState.Playing) return;

			foreach (var i in _filter)
			{
				ref var position = ref _filter.Get1(i).value;
				var speed = _filter.Get2(i).value;
				var dir = _filter.Get3(i).value;

				position += dir * speed * _runtimeData.deltaTime;
			}
		}
	}
}