using Cysharp.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Core
{
	public class PoolSystem<T> where T : MonoBehaviour
	{
		private ObjectPool<T> _pool;

		public T Prefab;

		public bool collectionChecks = true;
		public PoolSystem(T prefab, int basicCapacity, int maxPoolSize)
		{
			Prefab = prefab;

			_pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, basicCapacity, maxPoolSize);
			T[] a = new T[basicCapacity];

			for (int i = 0; i < basicCapacity; i++)
			{
				a[i] = _pool.Get();
			}
			for (int i = 0; i < basicCapacity; i++)
			{
				_pool.Release(a[i]);
			}
		}

		private T CreatePooledItem()
		{
			var go = Object.Instantiate(Prefab);
			return go;
		}
		private void OnReturnedToPool(T system)
		{
			system.gameObject.SetActive(false);
		}

		private void OnTakeFromPool(T system)
		{
			system.gameObject.SetActive(true);
		}
		private void OnDestroyPoolObject(T system)
		{
			Object.Destroy(system.gameObject);
		}

		public T Get(Vector3 generateWorldPositionFromView)
		{
			var entity = _pool.Get();
			entity.transform.position = generateWorldPositionFromView;
			return entity;
		}
		public void ReturnPool(T element)
		{
			element.gameObject.SetActive(false);
			_pool.Release(element);
		}
		public async UniTaskVoid ReturnPoolToTime(T element)
		{
			await UniTask.Delay(1200, cancellationToken: element.GetCancellationTokenOnDestroy());
			_pool.Release(element);
		}
	}
}