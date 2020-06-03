using UnityEngine;

public class Movable : MonoBehaviour {
    public Transform TRS;
    public Vector3 moveVector = Vector3.forward;

    private void OnValidate() => this.TRS = this.transform;

    private void Update() => this.TRS.position += this.moveVector;
}
