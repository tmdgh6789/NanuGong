using UnityEngine;
using System.Collections;

public class bgTimer : MonoBehaviour {

    timerScript _timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _timer = GameObject.FindObjectOfType<timerScript>();
	}
}
