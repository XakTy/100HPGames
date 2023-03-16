using Leopotam.Ecs;

namespace Core
{
	public sealed class DiedPlayerSystem : IEcsRunSystem
	{
		private readonly EcsFilter<PlayerTag, TransformRef, DiedEvent> _filter = default;

		private readonly EcsWorld _world = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				_world.ChangeState(GameState.Lose);
				
				
				_filter.Get2(i).value.gameObject.SetActive(false);
				_filter.GetEntity(i).Destroy();
			}
		}
	}
}