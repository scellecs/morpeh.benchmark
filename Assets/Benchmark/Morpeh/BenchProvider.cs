using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public sealed class BenchProvider : MonoProvider<BenchComponent> {
    private void OnValidate() {
        ref var data = ref this.GetData();
        data.transform = this.transform;
    }
}