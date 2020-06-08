using Pixeye.Actors;
using UnityEngine;

public class Bootstraper : MonoBehaviour {
    //Manual Initialization only for benchmark purpose
    private void Awake() {
        LayerKernel.Bootstrap();
    }
}
