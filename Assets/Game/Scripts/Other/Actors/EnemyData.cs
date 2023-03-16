using UnityEngine;

namespace Core.Actors
{
	[CreateAssetMenu(menuName = "GameData/EnemyData")]
	public sealed class EnemyData : ScriptableObject
	{
		public CubeActor Prefab;
		public int Health;
		public int Speed;
		public int Damage;
		public int BasicGold = 10;
	}
}