using Core.Actors;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Levels")]
        public Levels Levels;
        
        [Header("Required prefabs")]        
        public UI UI;
        public PlayerActor PlayerPrefab;
        public BulletActor BulletPrefab;
        public UpgradeView UpgradePrefab;
        public PopUp PopUpPrefab;
		public EnemyData[] EntitiesSpawn;

        public StateData[] Stats;
        public UpgradeStateData[] Upgrades;

        [Header("Settings")]
        public Vector2 Offset;
        public float LifeTimeBullet;
    }
}