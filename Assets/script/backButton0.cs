using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class backButton0 : MonoBehaviour {
    
    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            if (Input.GetKey(KeyCode.Escape)) {
                Application.Quit();
            }
        }
    }

}