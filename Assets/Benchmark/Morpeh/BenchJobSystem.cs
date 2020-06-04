using Morpeh;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Unity.Jobs;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BenchJobSystem))]
public sealed class BenchJobSystem : UpdateSystem {
    public GameObject prefab;
    public Vector3 moveVector = new Vector3(0f, 0f, 1f);
    private TransformAccessArray transforms;

    private Filter filter;
    
    public override void OnAwake() {
        this.transforms = new TransformAccessArray(CountInput.CountEntities);
        for (int i = 0, length = CountInput.CountEntities; i < length; i++) {
            var pos = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            var instance = Instantiate(this.prefab, pos, Quaternion.identity);
            this.transforms.Add(instance.transform);
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
        public void Execute(int index, TransformAccess transform) => transform.position += this.moveVector;
    }
}