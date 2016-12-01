using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TestModalWindow : MonoBehaviour {
    private ModalPanel modalPanel;
    private timerScript timer;
    private NetworkManager networkManager;
    private GameManager gameManager;
    public score score;

    public int coinValue;
    public float skin2Coin;
    public int myCoin;
    public int myScore;

    public string id;
    public int userCoin;
    public int userScore;

    private UnityAction myTenSecondsAction;
    private UnityAction myYesAction;
    private UnityAction myReAction;
    
    public GameObject bgmObj;
    public AudioSource bgmSource;

    void Awake() {
        modalPanel = ModalPanel.Instance();
        timer = FindObjectOfType<timerScript>();
        networkManager = FindObjectOfType<NetworkManager>();
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;

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
        if (PlayerPrefs.GetInt(id + "/Coin") >= 5) {
            GameObject.Find("playBGM").GetComponent<AudioSource>().Play();
            GameObject.Find("pauseButton").GetComponent<Button>().enabled = true;
            GameObject.Find("leftButton").GetComponent<Button>().enabled = true;
            GameObject.Find("rightButton").GetComponent<Button>().enabled = true;

            GameObject timeBar = GameObject.Find("timeBar");
            timer.timer = 10.0f;
            timeBar.transform.Translate(1.1f, 0.0f, 0.0f);
            PlayerPrefs.SetInt(id + "/Coin", (PlayerPrefs.GetInt(id + "/Coin") - 5));
            //setCoin();
        }
    }

    void TestYesFunction() {
        score = FindObjectOfType<score>();
        myCoin = PlayerPrefs.GetInt(id + "/Coin");
        myScore = PlayerPrefs.GetInt(id + "/BestScore");

        if (score.value > myCoin) {
            PlayerPrefs.SetInt(id + "/BestScore", myScore);
        }

        coinValue = (int)(score.value * 0.001);
        if (PlayerPrefs.GetInt(id + "/CurrentSkin") == 2) {
            skin2Coin = coinValue * 1.5f;
            PlayerPrefs.SetInt(id + "/Coin", (myCoin + (int)skin2Coin));
        } else {
            myCoin += coinValue;
            PlayerPrefs.SetInt(id + "/Coin", myCoin);
        }
        //setFinish();
        SceneManager.LoadScene(1);
    }

    void TestReFunction() {
        score = FindObjectOfType<score>();
        myCoin = PlayerPrefs.GetInt(id + "/Coin");
        myScore = PlayerPrefs.GetInt(id + "/BestScore");

        if (score.value > myCoin) {
            PlayerPrefs.SetInt(id + "/BestScore", myScore);
        }

        coinValue = (int)(score.value * 0.001);
        if (PlayerPrefs.GetInt(id + "/CurrentSkin") == 2) {
            skin2Coin = coinValue * 1.5f;
            PlayerPrefs.SetInt(id + "/Coin", (myCoin + (int)skin2Coin));
        } else {
            myCoin += coinValue;
            PlayerPrefs.SetInt(id + "/Coin", myCoin);
        }
        //setFinish();
        SceneManager.LoadScene(2);
    }

    void setFinish() {
        string id = PlayerPrefs.GetString("id");
        userCoin = PlayerPrefs.GetInt("Coin");
        userScore = PlayerPrefs.GetInt("BestScore");
        string strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/finish/" + id + "/" + userCoin + "/" + userScore;
        networkManager.network(strUrl);
    }

    void setCoin() {
        string id = PlayerPrefs.GetString("id");
        userCoin = PlayerPrefs.GetInt("Coin");
        string strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/coin/" + id + "/" + userCoin;
        networkManager.network(strUrl);
    }
}