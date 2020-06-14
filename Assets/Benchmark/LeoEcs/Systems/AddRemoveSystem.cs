using Leopotam.Ecs;
using Unity.IL2CPP.CompilerServices;

namespace Benchmarks.LeoEcs {
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption (Option.DivideByZeroChecks, false)]
    sealed class AddRemoveSystem : IEcsRunSystem {
        readonly EcsFilter<Movable, NonEmpty> _with = null;
        readonly EcsFilter<Movable>.Exclude<NonEmpty> _without = null;
        readonly LocalSharedState _lss = null;
        
        bool adding = true;

        public void Run () {
            if (adding) {
                foreach (var index in _without) {
                    for (int i = 0, length = _without.GetEntitiesCount () - 1; i < length; i += _lss.AddRemoveStep) {
                        _without.GetEntity (i).Get<NonEmpty> ();
                    }
                    break;
                }
            } else {
                foreach (var index in _with) {
                    for (int i = 0, length = _with.GetEntitiesCount () - 1; i < length; i += _lss.AddRemoveStep) {
                        _with.GetEntity (i).Del<NonEmpty> ();
                    }
                    break;
                }
            }

            adding = !adding;
        }
    }
}