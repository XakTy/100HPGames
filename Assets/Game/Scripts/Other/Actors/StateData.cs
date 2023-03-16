using UnityEngine;

namespace Core.Actors
{
	[CreateAssetMenu(menuName = "GameData/StatData")]
	public sealed class StateData : ScriptableObject
	{
		public string Key;
		public float StartValue;

		private void OnValidate()
		{
			if (string.IsNullOrEmpty(Key))
			{
				Key = name;
			}
		}
	}
}