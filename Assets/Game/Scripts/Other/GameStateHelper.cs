using Leopotam.Ecs;

namespace Core
{
    public static class GameStateHelper
    {
        public static void ChangeState(this EcsWorld world, GameState gameState)
        {
            world.NewEntity().Get<ChangeStateEvent>().NewGameState = gameState;
        }
    }
}