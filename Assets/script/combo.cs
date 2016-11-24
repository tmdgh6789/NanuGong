using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class combo : MonoBehaviour {
	public int value = 0;
    public Canvas comboCanvas;
	private Text comboValue;
    
    void Awake(){
		comboValue = GetComponent<Text>();
	}
	void Start () {
        comboCanvas.GetComponent<Canvas>().enabled = false;
    }
	
	void Update () {
		comboValue.text = "" + value;
        if (value >= 50) {
            feverMode.feverStart();
        }
	}
}
