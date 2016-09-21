using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class combo : MonoBehaviour {
	public float value = 0.0f;
	private Text comboValue;

	// Use this for initialization

	void Awake(){

		comboValue = this.GetComponent<Text> ();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		comboValue.text = string.Format ("{0:d1}", (int)value);

	
	}
}
