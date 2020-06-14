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
        if (this.adding) {
            for (int i = 0, length = this.without.Length - 1; i < length; i += CountInput.AddRemoveStep) {
                this.without.GetEntity(i).AddComponent<BenchAddRemoveComponent>();
            }
        } else {
            for (int i = 0, length = this.with.Length - 1; i < length; i += CountInput.AddRemoveStep) {
                this.with.GetEntity(i).RemoveComponent<BenchAddRemoveComponent>();
            }
        }

        this.adding = !this.adding;
    }
}