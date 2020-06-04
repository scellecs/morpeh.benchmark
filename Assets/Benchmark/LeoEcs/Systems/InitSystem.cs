using Leopotam.Ecs;
using Leopotam.Ecs.Types;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Benchmarks.LeoEcs {
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption (Option.DivideByZeroChecks, false)]
    sealed class InitSystem : IEcsInitSystem {
        readonly EcsWorld _world = null;
        readonly LocalSharedState _lss = null;

        public void Init () {
            _world.GetPool<Movable> ().SetCapacity (_lss.Count);
            for (int i = 0, iMax = _lss.Count; i < iMax; i++) {
                ref var movable = ref _world.NewEntity ().Get<Movable> ();
                movable.Position = new Float3 (Random.Range (-100f, 100f), Random.Range (-100f, 100f), Random.Range (-100f, 100f));
                movable.View = Object.Instantiate (_lss.Prefab, movable.Position, Quaternion.identity);
            }
        }
    }
}