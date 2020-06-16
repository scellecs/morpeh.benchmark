using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BenchAddRemoveSystem))]
public sealed class BenchAddRemoveSystem : UpdateSystem {
    private Filter with;
    private Filter without;

    private bool adding = true;

    public override void OnAwake() {
        this.with = this.World.Filter.With<BenchComponent>().With<BenchAddRemoveComponent>();
        this.without = this.World.Filter.With<BenchComponent>().Without<BenchAddRemoveComponent>();
    }

    public override void OnUpdate(float deltaTime) {
        var i = 0;
        if (this.adding) {
            foreach (var entity in this.without) { 
                if (i++ % CountInput.AddRemoveStep == 0) {
                    entity.AddComponent<BenchAddRemoveComponent>();
                }
            }
        } else {
            foreach (var entity in this.with) { 
                if (i++ % CountInput.AddRemoveStep == 0) {
                    entity.RemoveComponent<BenchAddRemoveComponent>();
                }
            }
        }

        this.adding = !this.adding;
    }
}