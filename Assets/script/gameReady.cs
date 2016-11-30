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
        strUrl = "http://localhost:5000/user/" + id;
        
        networkManager.network(strUrl);
        
        var obj = JSON.Parse(networkManager.strResult);

        userId = obj[0]["id"].ToString();
        userPw = obj[0]["password"].ToString();
        userNick = obj[0]["nickname"].ToString();
        int userScore;
        int.TryParse(obj[0]["bestScore"].ToString(), out userScore);
        int userCoin;
        int.TryParse(obj[0]["coin"].ToString(), out userCoin);
        int userMyChar;
        int.TryParse(obj[0]["myChar"].ToString(), out userMyChar);

        PlayerPrefs.SetString("id", userId);
        PlayerPrefs.SetString("Nick", userNick);
        PlayerPrefs.SetInt("BestScore", userScore);
        PlayerPrefs.SetInt("Coin", userCoin);
        PlayerPrefs.SetInt("CurrentSkin", userMyChar);

        userId = userId.Replace("\"", "");
        userPw = userPw.Replace("\"", "");
        userNick = userNick.Replace("\"", "");
    }

}