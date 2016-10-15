using UnityEngine;
using System.Collections;

public class coin100Plus : MonoBehaviour {

	// Use this for initialization
	public void OnMouseDown() {
        PlayerPrefs.SetInt("Coin", 100);
    }
}
