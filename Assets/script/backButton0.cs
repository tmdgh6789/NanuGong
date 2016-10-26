using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class backButton0 : MonoBehaviour {
    bool quitBool = false;

    void Update() {
        if (Input.GetKey(KeyCode.Escape) && quitBool) {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.Escape)) {
            quitBool = true;
        } else {
            quitBool = false;
        }
    }

}