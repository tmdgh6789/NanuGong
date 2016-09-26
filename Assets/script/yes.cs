using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class yes : MonoBehaviour {
    void OnMouseDown() {
        SceneManager.LoadScene(1);
    }
}
