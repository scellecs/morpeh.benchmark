using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[System.Serializable]
public struct BenchComponent : IComponent {
    public float3 position;
    public Transform transform;
}