using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class toMyRoom : MonoBehaviour {
    public void OnMouseDown() {
        SceneManager.LoadScene(4);
    }
}
