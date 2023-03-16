using System.Collections;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;
using Core.Actors;

namespace Core
{
	public sealed class Game : MonoBehaviour
    {
	    private EcsWorld _world;
	    private EcsSystems _systems;

        [SerializeField] private SceneData _sceneData;
		[SerializeField] private RuntimeData _runtimeData;
		[SerializeField] private StaticData _staticData;

        IEnumerator Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif


            _runtimeData = new RuntimeData();



            ServiceInject();
            GameInitialization.FullInit();
            Progress.SetUI(Service<UI>.Get());
			_systems
                // register your systems here, for example:
                .Add(new InitializeSystem())
                .Add(new ChangeStateSystem())
                .Add(new StartGameSystem())
                .Add(new InitPlayerSystem())
                .Add(new InitUpgradeSystem())
                .Add(new InitPoolSystem())
                .Add(new InitPositionSystem())

                .Add(new UpgradeClickEventSystem())
                .Add(new UpdateUpgradeView())
                .Add(new UpdateViewRange())

                .Add(new FindNearTargetSystem())

                .Add(new SpawnerBulletSystem())
                .Add(new SpawnerEnemySystem())

                .Add(new ReloadSystem())
                .Add(new LifeSystem())

                .Add(new MoveSystem())


                .Add(new BulletTriggerSystem())
                .Add(new EnemyTriggerSystem())

                .Add(new DamageSystem())

                .Add(new PopUpSystem())

                .OneFrame<HitInfo>()

                .Add(new DiedParticleSystem())

                .Add(new DiedPlayerSystem())
                .Add(new DiedEnemySystem())

                .Add(new UpdatePosition())
                
                // inject 

                .OneFrame<OnTriggerEnter>()
                .Inject(_sceneData)
                .Inject(_runtimeData)
                .Inject(_staticData)
                .Inject(Service<UI>.Get())

                .Init();
            yield return null;
        }

        private void ServiceInject()
        {
	        Service<SceneData>.Set(_sceneData);
	        Service<RuntimeData>.Set(_runtimeData);
	        Service<StaticData>.Set(_staticData);
	        Service<EcsWorld>.Set(_world);
        }

        void Update()
        {
	        _runtimeData.deltaTime = Time.deltaTime;
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}