using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timerScript : MonoBehaviour {
    public float timer;
    public float sec;
    public TestModalWindow TestModalWindow;
    private Text timerText;
    public Canvas comboCanvas;

    void Awake() {
        timerText = GetComponent<Text>();
        sec = 30.0f;
        timer = sec;
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            timer -= Time.deltaTime;
            timerText.text = "" + (int)timer;
        } else if (timer < 0) {
            timer = 0;
        } else {
            comboCanvas.GetComponent<Canvas>().enabled = false;
            TestModalWindow = FindObjectOfType<TestModalWindow>();
            TestModalWindow.Test();
        }
    }
}
