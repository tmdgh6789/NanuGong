using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timerScript : MonoBehaviour {
    public float timer;
    public static float sec;
    public TestModalWindow TestModalWindow;
    public coinText coinText;
    private Text timerText;
    public Canvas canvas;
    public Canvas comboCanvas;

    public GameObject leftButton;
    public GameObject rightButton;

    public GameObject[] starAnimObj = new GameObject[3];

    void Awake() {
        timerText = GetComponent<Text>();
        if (itemToggle.sec > 0) {
            sec = itemToggle.sec;
        } else {
            sec = 40.0f;
        }
        timer = sec;
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0 && timer < 6) {
            GameObject.Find("animCanvas").transform.FindChild("countPanel").gameObject.SetActive(true);
        } else {
            GameObject.Find("animCanvas").transform.FindChild("countPanel").gameObject.SetActive(false);
        }

        if (timer > 0) {
            
            timer -= Time.deltaTime;
            timerText.text = "" + (int)timer;

            leftButton = GameObject.Find("leftButton");
            rightButton = GameObject.Find("rightButton");

            if (leftButton.GetComponent<Button>().enabled == false || rightButton.GetComponent<Button>().enabled == false) {
                StartCoroutine("buttonActive");
            }

            for (int i = 0; i < 3; i++) {
                if (GameObject.Find("starAnim" + i + "(Clone)")) {
                    starAnimObj[i] = GameObject.Find("starAnim" + i + "(Clone)");
                }

                Destroy(starAnimObj[i], 0.3f);
            }

        } else if (timer < 0) {
            if (itemToggle.revival) {
                if (Random.Range(1, 100) <= itemToggle.revivalValue) {
                    StartCoroutine("revival");
                }
            }
             
            timer = 0;
        } else {
            GameObject.Find("playBGM").GetComponent<AudioSource>().Stop();

            GameObject.Find("animCanvas").transform.FindChild("countPanel").gameObject.SetActive(false);
            if (!itemToggle.revival) {
                GameObject.Find("pauseButton").GetComponent<Button>().enabled = false;
                GameObject.Find("leftButton").GetComponent<Button>().enabled = false;
                GameObject.Find("rightButton").GetComponent<Button>().enabled = false;
                comboCanvas.GetComponent<Canvas>().enabled = false;
                TestModalWindow = FindObjectOfType<TestModalWindow>();
                TestModalWindow.Test();
            }
        }
    }

    IEnumerator revival() {
        AudioSource[] esSources = GameObject.FindGameObjectWithTag("EffectSound").GetComponents<AudioSource>();
        esSources[7].Play();
        GameObject.Find("animCanvas").transform.FindChild("revivalModalPanel").gameObject.SetActive(true);

        yield return new WaitForSeconds(3.0f);

        timer = 40.0f;
        GameObject.Find("playBGM").GetComponent<AudioSource>().Play();
        GameObject.Find("animCanvas").transform.FindChild("revivalModalPanel").gameObject.SetActive(false);
        itemToggle.revival = false;
        GameObject.Find("timeBar").transform.position = new Vector2(0, transform.position.y);
    }

    IEnumerator buttonActive() {
        yield return new WaitForSeconds(0.5f);
        leftButton.GetComponent<Button>().enabled = true;
        rightButton.GetComponent<Button>().enabled = true;
    }
    
}