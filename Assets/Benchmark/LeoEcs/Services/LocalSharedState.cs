using Leopotam.Ecs.Types;
using UnityEngine;

namespace Benchmarks.LeoEcs {
    sealed class LocalSharedState {
        public int Count;
        public int AddRemoveStep;
        public Transform Prefab;
        public Float3 MoveVector = Float3.Forward;
    }
}