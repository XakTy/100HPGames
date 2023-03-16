using UnityEngine;

namespace Core.Actors
{
	[CreateAssetMenu(menuName ="GameData/PlayerData")]
	public sealed class PlayerData : ScriptableObject
	{
		public PlayerActor PrefabPlayer;
	}
}