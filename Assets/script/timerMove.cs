using UnityEngine;
using System;
using System.Collections;

public class timerMove : MonoBehaviour {

    timerScript _timer;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        _timer = GameObject.FindObjectOfType<timerScript>();
        float time = _timer.timer;
        
        if (time > 0) {
            this.transform.Translate(-0.0015f, 0.0f, 0.0f);
        } else {
            // ignore
        }
        
    }
}
