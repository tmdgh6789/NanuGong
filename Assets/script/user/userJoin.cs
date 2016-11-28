using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class userJoin : MonoBehaviour {
    private NetworkManager networkManager;

    public GameObject joinPanelObject;
    public GameObject loginPanelObject;
    public GameObject modifyPanelObject;
    public GameObject textPanelObject;
    public GameObject readyButtonPanelObject;
    public GameObject confirmPanelObject;

    public InputField inputId;
    public InputField inputPw;
    public InputField inputNick;
    public string id;
    public string pw;
    public string nick;

    public Text text;

    public string strUrl;
    public string strResult;

    public void Awake() {
        networkManager = FindObjectOfType<NetworkManager>();
    }

    public void OnMouseDown() {
        joinPanelObject.SetActive(true);
        loginPanelObject.SetActive(false);
        confirmPanelObject.SetActive(true);
        readyButtonPanelObject.SetActive(false);
    }

    public void joinOK() {
        inputId = GameObject.Find("joinPanel").transform.FindChild("joinImage").transform.FindChild("idInputField").GetComponent<InputField>();
        inputPw = GameObject.Find("joinPanel").transform.FindChild("joinImage").transform.FindChild("pwInputField").GetComponent<InputField>();
        inputNick = GameObject.Find("joinPanel").transform.FindChild("joinImage").transform.FindChild("nickInputField").GetComponent<InputField>();

        id = inputId.text;
        pw = inputPw.text;
        nick = inputNick.text;

        Debug.Log("1. id : " + id);
        Debug.Log("1. pw : " + pw);
        Debug.Log("1. nick : " + nick);
        StartCoroutine("inputCheck");

        Debug.Log("2. id : " + id);
        Debug.Log("2. pw : " + pw);
        Debug.Log("2. nick : " + nick);
        StartCoroutine("idCheck");

        Debug.Log("3. id : " + id);
        Debug.Log("3. pw : " + pw);
        Debug.Log("3. nick : " + nick);
        StartCoroutine("joinSuccess");

        Debug.Log("4. id : " + id);
        Debug.Log("4. pw : " + pw);
        Debug.Log("4. nick : " + nick);
    }

    public void joinCancel() {
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();
        text.text = "닉네임 변경을 취소하셨습니다.";
        modifyPanelObject.SetActive(false);
        confirmPanelObject.SetActive(false);
        Invoke("hideAndShow", 1.0f);
    }

    IEnumerator inputCheck() {
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();

        if (id == "") {
            text.text = "아이디를 입력해주세요!";
        } else if (pw == "") {
            text.text = "비밀번호를 입력해주세요!";
        } else if (nick == "") {
            text.text = "닉네임을 입력해주세요!";
        }

        yield return new WaitForSeconds(0.8f);

        textPanelObject.SetActive(false);
    }

    IEnumerator idCheck() {
        login();
        
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();

        if (networkManager.strResult != "") {
            text.text = "아이디가 이미 존재합니다!";
        }
        yield return new WaitForSeconds(0.8f);

        textPanelObject.SetActive(false);
    }

    IEnumerator joinSuccess() {
        join();

        joinPanelObject.SetActive(false);
        confirmPanelObject.SetActive(false);
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();
        text.text = "회원가입을 완료했습니다!";

        yield return new WaitForSeconds(0.8f);

        textPanelObject.SetActive(false);
        loginPanelObject.SetActive(true);
        readyButtonPanelObject.SetActive(true);
    }

    public void join() {
        // 요청을 보내는 URl
        strUrl = "http://localhost:5000/join/" + id + "/" + pw + "/" + nick;

        networkManager.network(strUrl);
    }

    public void login() {
        // 요청을 보내는 URl
        strUrl = "http://localhost:5000/user/" + id;

        networkManager.network(strUrl);
    }
}
