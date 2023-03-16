using System;

namespace Core
{
    [Serializable]
    public class RuntimeData
    {
        public int Level;
        public GameState GameState;
        public float LevelStartedTime;

        public float deltaTime;
    }
}