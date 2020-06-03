using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BenchSystem))]
public sealed class BenchSystem : UpdateSystem {
    public GameObject prefab;
    public Vector3    moveVector = Vector3.forward;

    private Filter filter;
    
    public override void OnAwake() {
        for (int i = 0, length = CountInput.CountEntities; i < length; i++) {
            var pos = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            Instantiate(this.prefab, pos, Quaternion.identity);
        }

        this.filter = this.World.Filter.With<BenchComponent>();
    }

    public override void OnUpdate(float deltaTime) {
        var posBag = this.filter.Select<BenchComponent>();

        for (int i = 0, length = this.filter.Length; i < length; i++) {
            ref var bench = ref posBag.GetComponent(i);
            bench.transform.position += this.moveVector;
        }
    }
}