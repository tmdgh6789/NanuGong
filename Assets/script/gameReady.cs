using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using System.Text;
using System.IO;
using System.Collections;
using System.Net.Json;

public class gameReady : MonoBehaviour {

    public InputField inputId;
    public InputField inputPw;
    public InputField inputNick;
    public string id;
    public string pw;
    public string nick;

    public string strUrl;
    public string strResult;

    public GameObject joinPanelObject;
    public GameObject loginPanelObject;
    public GameObject textPanelObject;
    public GameObject confirmPanelObject;
    public GameObject nickModifyObject;
    public Text text;

    public GameObject bgmObj;
    public GameObject esObj;

    void Start() {
        string userName = PlayerPrefs.GetString("Nick");
        // id 찾는 함수

        if (userName == "") {
            joinPanelObject.SetActive(true);
            loginPanelObject.SetActive(false);
            textPanelObject.SetActive(false);
            nickModifyObject.SetActive(false);
        } else {
            joinPanelObject.SetActive(false);
            textPanelObject.SetActive(true);
            text = GameObject.Find("text").GetComponent<Text>();
            text.text = userName + "님 반갑습니다.\nREADY 버튼을 눌러주세요!";
            loginPanelObject.SetActive(true);
            nickModifyObject.SetActive(true);
        }
    }

    public void OnMouseDown() {
        bgmObj = GameObject.Find("BGM");
        esObj = GameObject.Find("effectSound");

        id = inputId.text;
        pw = inputPw.text;
        nick = inputNick.text;

        if (joinPanelObject.activeSelf == false) {
            bgmObj.GetComponent<AudioSource>().Pause();
            DontDestroyOnLoad(bgmObj);
            DontDestroyOnLoad(esObj);
            SceneManager.LoadScene(1);
        } else {
            if (id == "") {
                joinPanelObject.SetActive(false);
                textPanelObject.SetActive(true);
                text = GameObject.Find("text").GetComponent<Text>();
                text.text = "닉네임을 입력해주세요!";
                Invoke("noNick", 0.5f);
            } else {
                StartCoroutine("loadReady");
            }
        }
    }

    void HideText() {
        textPanelObject.SetActive(false);
    }

    void noNick() {
        textPanelObject.SetActive(false);
        joinPanelObject.SetActive(true);
    }

    IEnumerator loadReady() {
        PlayerPrefs.SetString("Nick", nick);
        PlayerPrefs.SetString("CurrentSkin", "default");
        PlayerPrefs.SetInt("Coin", 100);
        PlayerPrefs.SetInt("BestScore", 0);

        joinPanelObject.SetActive(false);
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();
        text.text = nick + "님 반갑습니다.\n곧 게임이 시작됩니다.\n잠시만 기다려주세요!";

        yield return new WaitForSeconds(1.5f);

        join();
        bgmObj.GetComponent<AudioSource>().Pause();
        DontDestroyOnLoad(bgmObj);
        DontDestroyOnLoad(esObj);
        SceneManager.LoadScene(1);

    }
    
    public void join() {
        // 요청을 보내는 URl
        strUrl = "http://localhost:5000/join/"+ id +"/" + pw + "/" + nick;

        network(strUrl);
    }

    public void login() {
        // 요청을 보내는 URl
        strUrl = "http://localhost:5000/user/" + id;

        network(strUrl);
        
        // json 파싱
        JsonTextParser parser = new JsonTextParser();
        JsonObject obj = parser.Parse(strResult);
        JsonObjectCollection col = (JsonObjectCollection)obj;

        string existId = (string)col["id"].GetValue();
        
    }

    public void network(string strUrl) {
        /* GET */
        // HttpWebRequest 객체 생성, 설정
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strUrl);
        request.Method = "GET";    // 기본값 "GET"
        request.ContentType = "application/x-www-form-urlencoded";

        // 요청, 응답 받기
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        // 응답 Stream 읽기
        Stream stReadData = response.GetResponseStream();
        StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

        // 응답 Stream -> 응답 String 변환
        strResult = srReadData.ReadToEnd();

        Debug.Log(strResult);
    }
}