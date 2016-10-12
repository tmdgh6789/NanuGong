using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameStart : MonoBehaviour {
	public void OnMouseDown() {
        SceneManager.LoadScene(2);
    }
}
