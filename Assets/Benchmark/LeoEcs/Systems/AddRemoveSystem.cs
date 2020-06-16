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
        
        bool _adding = true;

        public void Run () {
            var i = 0;
            
            if (_adding) {
                foreach (var index in _without) {
                    if (i++ % _lss.AddRemoveStep == 0) {
                        _without.GetEntity (index).Get<NonEmpty> ();
                    }
                }
            } else {
                foreach (var index in _with) {
                    if (i++ % _lss.AddRemoveStep == 0) {
                        _with.GetEntity (index).Del<NonEmpty> ();
                    }
                }
            }

            _adding = !_adding;
        }
    }
}