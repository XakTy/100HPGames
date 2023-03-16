using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
	public static class PoolDict<TKey, TValue> where TValue : MonoBehaviour
	{
		private static Dictionary<TKey, PoolInfo<TValue>> _pool;

		public static void ResetPool()
		{
			_pool = new Dictionary<TKey, PoolInfo<TValue>>();
		}
		public static void Add(TKey key, TValue prefab, int basicCount, int maxCount)
		{
			var newInfo = new PoolInfo<TValue>();

			newInfo.Prefab = prefab;

			var stack = new Stack<TValue>(maxCount);

			for (int i = 0; i < basicCount; i++)
			{
				var newEntity = Object.Instantiate(prefab);
				newEntity.gameObject.SetActive(false);
				stack.Push(newEntity);
			}

			newInfo.Stack = stack;

			_pool.Add(key, newInfo);
		}

		public static TValue Get(TKey key, Vector3 position)
		{
			if (_pool[key].Count == 0)
			{
				var newEntity = Object.Instantiate(_pool[key].Prefab, position, Quaternion.identity);
				return newEntity;
			}

			var getEntity = _pool[key].Stack.Pop();
			getEntity.transform.position = position;
			return getEntity;
		}

		public static async UniTaskVoid ReturnPoolToTime(TKey element, TValue actor, float time, bool startFalse = true)
		{
			actor.gameObject.SetActive(startFalse);
			await UniTask.Delay(TimeSpan.FromSeconds(time), cancellationToken: actor.GetCancellationTokenOnDestroy());
			_pool[element].Stack.Push(actor);
			actor.gameObject.SetActive(false);
		}
		public static void Return(TKey key, TValue actor)
		{
			actor.gameObject.SetActive(false);
			_pool[key].Stack.Push(actor);
		}

		public static void Return(TKey key, TValue actor, Vector3 position)
		{
			actor.gameObject.SetActive(false);
			actor.gameObject.transform.position = position;
			_pool[key].Stack.Push(actor);
		}
	}
}