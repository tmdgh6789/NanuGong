using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class combo : MonoBehaviour {
	public int value = 0;
    public Canvas comboCanvas;
	private Text comboValue;

    // Use this for initialization

    void Awake(){
		comboValue = GetComponent<Text>();
	}
	void Start () {
        comboCanvas.GetComponent<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		comboValue.text = "" + value;
	}
}
