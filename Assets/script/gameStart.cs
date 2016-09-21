using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameStart : MonoBehaviour {

	void OnMouseDown() {
        SceneManager.LoadScene(2);
    }
}
