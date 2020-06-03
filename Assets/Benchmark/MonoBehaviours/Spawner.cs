using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {
    public GameObject prefab;

    public void Awake() {
        for (int i = 0, length = CountInput.CountEntities; i < length; i++) {
            var pos = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
            Instantiate(this.prefab, pos, Quaternion.identity);
        }
    }
}
