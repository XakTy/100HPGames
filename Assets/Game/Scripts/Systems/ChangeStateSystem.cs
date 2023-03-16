using System;
using Leopotam.Ecs;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

namespace Core
{
	public sealed class ChangeStateSystem : IEcsRunSystem
    {
        private readonly UI _ui = default;

        private readonly EcsFilter<ChangeStateEvent> _filter = default;

        private readonly RuntimeData _runtimeData = default;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var state = _filter.Get1(i).NewGameState;
                _runtimeData.GameState = state;
                switch (state)
                {
                    case GameState.Before:
                        _ui.MenuScreen.Show(true);
                        _ui.GameScreen.Show(false);
                        break;
                    case GameState.Playing:
                        _runtimeData.LevelStartedTime = Time.realtimeSinceStartup;
                        
                        _ui.MenuScreen.Show(false);
                        _ui.GameScreen.Show(true);
                        break;
                    case GameState.Lose:

	                    _ui.GameScreen.Show(false);
                        _ui.LoseScreen.Show(true);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}