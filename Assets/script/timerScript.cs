using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timerScript : MonoBehaviour {
    public float timer;
    public static float sec;
    public TestModalWindow TestModalWindow;
    private Text timerText;
    public Canvas canvas;
    public Canvas comboCanvas;

    void Awake() {
        timerText = GetComponent<Text>();
        if (itemToggle.sec > 0) {
            sec = itemToggle.sec;
        } else {
            sec = 30.0f;
        }
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
            GameObject.Find("pauseButton").GetComponent<Button>().enabled = false;
            GameObject.Find("leftButton").GetComponent<Button>().enabled = false;
            GameObject.Find("rightButton").GetComponent<Button>().enabled = false;
            comboCanvas.GetComponent<Canvas>().enabled = false;
            TestModalWindow = FindObjectOfType<TestModalWindow>();
            TestModalWindow.Test();
        }
    }
}