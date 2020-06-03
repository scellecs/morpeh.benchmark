using Morpeh;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Unity.Jobs;
using UnityEngine.Jobs;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BenchJobSystem))]
public sealed class BenchJobSystem : UpdateSystem {
    public GameObject prefab;
    public Vector3 moveVector = Vector3.forward;
    private TransformAccessArray transforms;

    private Filter filter;
    
    public override void OnAwake() {
        for (int i = 0, length = CountInput.CountEntities; i < length; i++) {
            var pos = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            Instantiate(this.prefab, pos, Quaternion.identity);
        }

        this.filter = this.World.Filter.With<BenchComponent>();
        this.World.UpdateFilters();
        
        this.transforms = new TransformAccessArray(this.filter.Length);
        foreach (var entity in this.filter) {
            ref var bench = ref entity.GetComponent<BenchComponent>();
            this.transforms.Add(bench.transform);
        }
    }

    public override void OnUpdate(float deltaTime) {
        var newJob = new MoveJob {
            moveVector = this.moveVector
        };

        var handle = newJob.Schedule(this.transforms);
        JobHandle.ScheduleBatchedJobs();
        handle.Complete();
    }

    public override void Dispose() {
        this.transforms.Dispose();
    }

    [BurstCompile]
    public struct MoveJob : IJobParallelForTransform {
        [ReadOnly]
        public Vector3 moveVector;
        public void Execute(int index, TransformAccess transform) {
            transform.position += this.moveVector;
        }
    }
}