using Leopotam.Ecs;
using Unity.IL2CPP.CompilerServices;

namespace Benchmarks.LeoEcs {
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption (Option.DivideByZeroChecks, false)]
    sealed class MoveSystem : IEcsRunSystem {
        readonly EcsFilter<Movable> _movables = null;
        readonly LocalSharedState _lss = null;

        public void Run () {
            for (int idx = 0, idxMax = _movables.GetEntitiesCount (); idx < idxMax; idx++) {
                ref var movable = ref _movables.Get1 (idx);
                movable.Position += _lss.MoveVector;
                movable.View.localPosition = movable.Position;
            }
        }
    }
}