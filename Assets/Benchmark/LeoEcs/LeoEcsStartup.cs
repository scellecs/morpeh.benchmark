using Leopotam.Ecs;
using UnityEngine;

namespace Benchmarks.LeoEcs {
    sealed class LeoEcsStartup : MonoBehaviour {
        [SerializeField] Transform _prefab;
        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            var lss = new LocalSharedState ();
            lss.Count = CountInput.CountEntities;
            lss.Prefab = _prefab;

            var worldCfg = new EcsWorldConfig () {
                FilterEntitiesCacheSize = lss.Count,
                WorldEntitiesCacheSize = lss.Count,
            };

            _world = new EcsWorld (worldCfg);
            _systems = new EcsSystems (_world);
            _systems
                .Add (new InitSystem ())
                .Add (new MoveSystem ())
                .Inject (lss)
                .Init ();
        }

        void Update () {
            _systems.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}