using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

namespace Core
{
	public sealed class UpdateViewRange : IEcsRunSystem
	{
		private readonly EcsFilter<ViewRange, Stats, UpdateView> _filter = default;
		public void Run()
		{
			foreach (var i in _filter)
			{
				var entity = _filter.GetEntity(i);

				var view = _filter.Get1(i).value;
				var spells = _filter.Get2(i).value;

				var rangeValue = spells[Const.StateRange].Value;

				view.DOKill();
				view.DOScale(new Vector3(rangeValue, rangeValue, 0), 0.5f);

				entity.Del<UpdateView>();
			}
		}
	}
}