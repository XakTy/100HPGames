using UnityEngine;

namespace Core
{
	public struct View<T> where T : MonoBehaviour
	{
		public T value;
	}
}