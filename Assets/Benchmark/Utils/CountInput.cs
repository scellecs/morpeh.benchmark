using System;
using UnityEngine;
using UnityEngine.UI;

public class CountInput : MonoBehaviour {
    public static int CountEntities = 100_000;
    public static int AddRemoveStep = 10;
    
    public enum InputType
    {
        CountEntities,
        AddRemoveStep
    }

    public InputField input;
    public InputType inputType;

    private void OnValidate() => this.input = this.GetComponent<InputField>();

    private void Start() {
        switch (inputType) {
            case InputType.CountEntities:
                this.input.text = CountEntities.ToString();
                break;
            case InputType.AddRemoveStep:
                this.input.text = AddRemoveStep.ToString();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        this.input.onEndEdit.AddListener(this.OnValueChange);
    }

    public void OnValueChange(string newText) {
        if (!int.TryParse(newText, out var newValue)) return;
        
        switch (this.inputType) {
            case InputType.CountEntities:
                CountEntities = newValue;
                break;
            case InputType.AddRemoveStep:
                AddRemoveStep = newValue;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
