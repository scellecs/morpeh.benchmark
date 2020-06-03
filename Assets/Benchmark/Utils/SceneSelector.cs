using System.Collections;
using System.Collections.Generic;
using Morpeh.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour {
    public SceneReference scene;

    public void OnClick() {
        SceneManager.LoadScene(this.scene);
    }
}
