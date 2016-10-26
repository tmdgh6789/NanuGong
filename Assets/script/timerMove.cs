using UnityEngine;
using System.Collections;

public class timerMove : MonoBehaviour {

    timerScript _timer;

    public bool move;
    // Use this for initialization
    void Start () {
        move = true;
    }
	
	// Update is called once per frame
	void Update () {
        _timer = FindObjectOfType<timerScript>();
        float time = _timer.timer;
        
        if (time > 0 && move) {
            transform.Translate(-0.002f, 0.0f, 0.0f);
        }
    }
}
