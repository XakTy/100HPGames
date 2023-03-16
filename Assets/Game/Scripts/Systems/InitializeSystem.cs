using Leopotam.Ecs;
using UnityEditor.PackageManager;

namespace Core
{
	public sealed class InitializeSystem : IEcsInitSystem
    {
        private readonly UI _ui = default;

        private readonly EcsWorld _world = default;

        private readonly RuntimeData _runtimeData = default;

        public void Init()
        {
            _ui.CloseAll();
            _ui.GameScreen.CurrentMoneyText.text = Progress.Money.ToString();
            _runtimeData.Level = Progress.CurrentLevel;
            _world.ChangeState(GameState.Before);
            _world.NewEntity().Get<Spawner>();

        }
    }
}