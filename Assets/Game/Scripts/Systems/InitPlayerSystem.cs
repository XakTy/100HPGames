using System.Linq;
using Leopotam.Ecs;
using UnityEngine;

namespace Core
{
	public sealed class InitPlayerSystem : IEcsInitSystem
	{
		private readonly UI _ui = default;

		private readonly EcsWorld _world = default;

		private readonly RuntimeData _runtimeData = default;

		private readonly StaticData _staticData = default;

		private readonly SceneData _sceneData = default;
		public void Init()
		{
			var player = Object.Instantiate(_staticData.PlayerPrefab, _sceneData.SpawnPoint.position, Quaternion.identity);
			player.Init();
			player.Entity.Get<Stats>().value = _staticData.Stats.ToDictionary(x => x.Key, x => new StatValue(x.StartValue));
			player.Entity.Get<Health>().value = player.Entity.Get<Stats>().value[Const.StateHealth].Value;


			player.Entity.Get<Stats>().value[Const.StateRange].OnValueChanged += () =>
			{
				player.Entity.Get<UpdateView>();
			};

		}
	}
}