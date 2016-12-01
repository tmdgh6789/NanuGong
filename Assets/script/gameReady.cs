using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using SimpleJSON;

public class gameReady : MonoBehaviour {

    private NetworkManager networkManager;

    public InputField inputId;
    public InputField inputPw;
    public InputField inputNick;
    public string id;
    public string pw;
    public string nick;

    public string userId;
    public string userPw;
    public string userNick;

    public string strUrl;
    public string strResult;

    public GameObject joinPanelObject;
    public GameObject joinButtonPanelObject;
    public GameObject loginPanelObject;
    public GameObject coinPanelObject;
    public GameObject textPanelObject;
    public GameObject confirmPanelObject;
    public GameObject nickModifyObject;
    public Text text;

    public GameObject bgmObj;
    public GameObject esObj;
    
    public void Awake() {
        networkManager = FindObjectOfType<NetworkManager>();

        bgmObj = GameObject.Find("BGM");
        esObj = GameObject.Find("effectSound");

        PlayerPrefs.DeleteAll();

    }

    public void OnMouseDown() {
        inputId = GameObject.Find("idInputField").GetComponent<InputField>();
        inputPw = GameObject.Find("pwInputField").GetComponent<InputField>();

        id = inputId.text;
        pw = inputPw.text;

        if (id == "" || pw == "") {
            StartCoroutine("noInput");
        } else {
            StartCoroutine("loadReady");
        }
    }

    void HideText() {
        textPanelObject.SetActive(false);
    }

    IEnumerator noInput() {
        loginPanelObject.SetActive(false);
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();

        if (id == "") {
            text.text = "아이디를 입력해주세요!";
        } else if (pw == "") {
            text.text = "비밀번호를 입력해주세요!";
        }

        yield return new WaitForSeconds(0.5f);

        textPanelObject.SetActive(false);
        loginPanelObject.SetActive(true);
    }

    IEnumerator loadReady() {
        login();
        
        if (id == userId) {     //id 맞았을 때
            if (pw == userPw) {     //pw도 맞았을 때
                textPanelObject.SetActive(true);
                text = GameObject.Find("text").GetComponent<Text>();
                text.text = userNick + "님 반갑습니다.\n곧 게임이 시작됩니다.\n잠시만 기다려주세요!";

                yield return new WaitForSeconds(1.5f);

                bgmObj.GetComponent<AudioSource>().Pause();
                DontDestroyOnLoad(bgmObj);
                DontDestroyOnLoad(esObj);
                SceneManager.LoadScene(1);
            } else {        //pw는 틀렸을 때
                textPanelObject.SetActive(true);
                text = GameObject.Find("text").GetComponent<Text>();
                text.text = "아이디 또는 비밀번호를 확인해주세요!";
            }
        } else {        //id 틀렸을 때
            textPanelObject.SetActive(true);
            text = GameObject.Find("text").GetComponent<Text>();
            text.text = "아이디 또는 비밀번호를 확인해주세요!";
        }
    }

    public void login() {
        // 요청을 보내는 URl
        strUrl = "http://192.168.0.5:5000/user/" + id;
        networkManager.network(strUrl);
        var user = JSON.Parse(networkManager.strResult);

        strUrl = "http://192.168.0.5:5000/inventory/" + id;
        networkManager.network(strUrl);
        var inven = JSON.Parse(networkManager.strResult);

        userId = user[0]["id"].ToString();
        userPw = user[0]["password"].ToString();
        userNick = user[0]["nickname"].ToString();
        string userScore = user[0]["bestScore"].ToString();
        string userCoin = user[0]["coin"].ToString();
        string userMyChar = user[0]["myChar"].ToString();

        string myChar1 = inven[0]["char1"].ToString();
        string myChar2 = inven[0]["char2"].ToString();
        string myChar3 = inven[0]["char3"].ToString();
        string myChar4 = inven[0]["char4"].ToString();

        userId = userId.Replace("\"", "");
        userPw = userPw.Replace("\"", "");
        userNick = userNick.Replace("\"", "");
        userScore = userScore.Replace("\"", "");
        userCoin = userCoin.Replace("\"", "");
        userMyChar = userMyChar.Replace("\"", "");
        myChar1 = myChar1.Replace("\"", "");
        myChar2 = myChar2.Replace("\"", "");
        myChar3 = myChar3.Replace("\"", "");
        myChar4 = myChar4.Replace("\"", "");

        int intScore;
        int.TryParse(userScore, out intScore);
        int intCoin;
        int.TryParse(userCoin, out intCoin);
        int intMyChar;
        int.TryParse(userMyChar, out intMyChar);
        int intMyChar1;
        int.TryParse(myChar1, out intMyChar1);
        int intMyChar2;
        int.TryParse(myChar2, out intMyChar2);
        int intMyChar3;
        int.TryParse(myChar3, out intMyChar3);
        int intMyChar4;
        int.TryParse(myChar4, out intMyChar4);
        
        PlayerPrefs.SetString("id", userId);
        PlayerPrefs.SetString("Nick", userNick);
        PlayerPrefs.SetInt("BestScore", intScore);
        PlayerPrefs.SetInt("Coin", intCoin);
        PlayerPrefs.SetInt("CurrentSkin", intMyChar);

        if (intMyChar1 == 1) {
            PlayerPrefs.SetString("skin1", "Y");
        }

        if (intMyChar2 == 1) {
            PlayerPrefs.SetString("skin2", "Y");
        }

        if (intMyChar3 == 1) {
            PlayerPrefs.SetString("skin3", "Y");
        }

        if (intMyChar4 == 1) {
            PlayerPrefs.SetString("skin4", "Y");
        }
    }

}