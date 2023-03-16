using System.Collections.Generic;

namespace Core
{
	public struct PoolInfo<T>
	{
		public T Prefab;
		public Stack<T> Stack;

		public int Count => Stack.Count;
	}
}