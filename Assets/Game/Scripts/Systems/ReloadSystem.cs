using Leopotam.Ecs;

namespace Core
{
	public sealed class ReloadSystem : IEcsRunSystem
	{
		private readonly EcsFilter<Reload> _filter = default;

		private readonly RuntimeData _runtimeData = default;
		public void Run()
		{
			if (_filter.IsEmpty()) return;

			foreach (var i in _filter)
			{
				ref var reload = ref _filter.Get1(i).value;
				reload -= _runtimeData.deltaTime;

				if (reload <= 0)
				{
					var entity = _filter.GetEntity(i);
					entity.Del<Reload>();
				}

			}
		}
	}
}