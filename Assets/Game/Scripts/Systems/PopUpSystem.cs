using Core.Actors;
using Leopotam.Ecs;

namespace Core
{
	public sealed class PopUpSystem : IEcsRunSystem
	{
		private readonly EcsFilter<HitInfo> _filter = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				ref var hitInfo = ref _filter.Get1(i);

				var newPopUp = PoolDict<SingleEntity, PopUp>.Get(SingleEntity.PopUp, hitInfo.Position);

				newPopUp.gameObject.SetActive(true);

				newPopUp.PopUpText.text = hitInfo.value.ToString();

				PoolDict<SingleEntity, PopUp>.ReturnPoolToTime(SingleEntity.PopUp, newPopUp, 1200);

			}
		}
	}
}