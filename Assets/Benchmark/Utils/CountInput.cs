using System;
using UnityEngine;
using UnityEngine.UI;

public class CountInput : MonoBehaviour {
    public static int CountEntities = 100_000;
    public InputField input;

    private void OnValidate() => this.input = this.GetComponent<InputField>();

    private void Start() {
        this.input.text = CountEntities.ToString();
        this.input.onEndEdit.AddListener(this.OnValueChange);
    }

    public void OnValueChange(string newText) {
        if (int.TryParse(newText, out var newValue)) {
            CountEntities = newValue;
        }
    }
}
