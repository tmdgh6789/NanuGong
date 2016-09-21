using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timerScript : MonoBehaviour {
    public float timer;
    public float sec;
    private Text timerText;

    void Awake() {
        timerText = GetComponent<Text> ();
        sec = 60.0f;
        timer = sec;
    }

    // Update is called once per frame
    void Update() {
        timerText.transform.Translate(-0.04f, 0.0f, 0.0f);

        if (timer > 0) {
            timer -= Time.deltaTime;
            timerText.text = "" + (int)timer;
        } else {
        }
    }


    private void OnTimer() {
        // ...
    }

    // Use this for initialization
    void Start () {
	
	}
	
}
