using System.Runtime.CompilerServices;
using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using Random = UnityEngine.Random;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BenchSystem))]
public sealed class BenchSystem : UpdateSystem {
    public GameObject prefab;
    public float3 moveVector = new float3(0f, 0f, 1f);

    private Filter filter;
    
    public override void OnAwake() {
        for (int i = 0, length = CountInput.CountEntities; i < length; i++) {
            var entity = this.World.CreateEntity();
            var pos = new float3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            var instance = Instantiate(this.prefab, pos.ToVector3(), Quaternion.identity);
            
            entity.SetComponent(new BenchComponent {
                position = pos,
                transform = instance.transform
            });
        }

        this.filter = this.World.Filter.With<BenchComponent>();
    }

    public override void OnUpdate(float deltaTime) {
        var posBag = this.filter.Select<BenchComponent>();

        for (int i = 0, length = this.filter.Length; i < length; i++) {
            ref var bench = ref posBag.GetComponent(i);
            bench.position += this.moveVector;
            bench.transform.position = bench.position.ToVector3();
        }
    }
}

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
public static class Float3Extensions {
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vector3 ToVector3(this float3 f3) {
        Vector3 v;
        v.x = f3.x;
        v.y = f3.y;
        v.z = f3.z;
        return v;
    }
}