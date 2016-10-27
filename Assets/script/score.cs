using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class score : MonoBehaviour {

	public float value = 0.0f;
	private Text scoreValue;
    
	// Update is called once per frame
	void Update () {
        scoreValue = GetComponent<Text>();
        scoreValue.text = "" + (int)value;
	}
}
