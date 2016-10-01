using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class combo : MonoBehaviour {
	public float value = 0.0f;
	private Text comboValue;
    public GameObject comboPanel;

    // Use this for initialization

    void Awake(){
		comboValue = GetComponent<Text>();
	}
	void Start () {
        comboPanel = GameObject.FindGameObjectWithTag("comboPanel");
	}
	
	// Update is called once per frame
	void Update () {
		comboValue.text = string.Format("{0:d1}", (int)value);
	}
}
