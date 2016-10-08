using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class backButton2 : MonoBehaviour {
    
    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene(1);
        }
    }

}