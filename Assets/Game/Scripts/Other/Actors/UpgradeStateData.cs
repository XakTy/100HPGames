using UnityEngine;

namespace Core.Actors
{
	[CreateAssetMenu(menuName = "GameData/UpgradeData")]
	public sealed class UpgradeStateData : ScriptableObject
	{
		public StateData State;

		public string Name;

		[Min(0)] public int StartPrice;
		[Min(0)] public int IncreasePriceLevel;
		[Min(0)] public float IncreaseValue;
		[Min(1)] public int Maxlevel;
	}
}