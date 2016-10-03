using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class score : MonoBehaviour {

	public float value = 0.0f;
	private Text scoreValue;

	void Awake(){
		scoreValue = GetComponent<Text> ();
	}


	// Use this for initialization


	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		scoreValue.text = "" + (int)value;
	}
}
