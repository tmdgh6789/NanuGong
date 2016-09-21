using UnityEngine;
using System.Collections;

public class timerMove : MonoBehaviour {
	
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(-0.0009f, 0.0f, 0.0f);
    }
}
