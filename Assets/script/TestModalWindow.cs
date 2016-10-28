using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TestModalWindow : MonoBehaviour {
    private ModalPanel modalPanel;
    private timerScript timer;
    public score score;
    public int coinValue;
    public float skin2Coin;
    public int myCoin;


    private UnityAction myTenSecondsAction;
    private UnityAction myYesAction;
    private UnityAction myReAction;
    
    public GameObject bgmObj;
    public AudioSource bgmSource;

    void Awake() {
        modalPanel = ModalPanel.Instance();
        timer = FindObjectOfType<timerScript>();

        myTenSecondsAction = new UnityAction(TestTenSecondsFunction);
        myYesAction = new UnityAction(TestYesFunction);
        myReAction = new UnityAction(TestReFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void Test() {
        modalPanel.Choice(TestTenSecondsFunction, TestYesFunction, TestReFunction);
    }

    //  These are wrapped into UnityActions
    void TestTenSecondsFunction() {
        if (PlayerPrefs.GetInt("Coin") >= 5) {
            GameObject.Find("playBGM").GetComponent<AudioSource>().Play();
            GameObject.Find("pauseButton").GetComponent<Button>().enabled = true;
            GameObject.Find("leftButton").GetComponent<Button>().enabled = true;
            GameObject.Find("rightButton").GetComponent<Button>().enabled = true;

            GameObject timeBar = GameObject.Find("timeBar");
            timer.timer = 10.0f;
            timeBar.transform.Translate(1.1f, 0.0f, 0.0f);
            PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") - 5));
        }
    }

    void TestYesFunction() {
        score = FindObjectOfType<score>();
        myCoin = PlayerPrefs.GetInt("Coin");

        coinValue = (int)(score.value * 0.001);
        if (PlayerPrefs.GetString("CurrentSkin") == "skin2") {
            skin2Coin = coinValue * 1.5f;
            PlayerPrefs.SetInt("Coin", (myCoin + (int)skin2Coin));
        } else {
            myCoin += coinValue;
            PlayerPrefs.SetInt("Coin", myCoin);
        }
        SceneManager.LoadScene(1);
    }

    void TestReFunction() {
        SceneManager.LoadScene(2);
    }

}