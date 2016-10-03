using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class shopBefore : MonoBehaviour {
    public void OnMouseDown() {
        SceneManager.LoadScene(1);
    }
}
