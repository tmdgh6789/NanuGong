using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class userJoin : MonoBehaviour {
    private NetworkManager networkManager;
    private GameManager gameManager;

    public GameObject joinPanelObject;
    public GameObject joinButtonPanelObject;
    public GameObject loginPanelObject;
    public GameObject textPanelObject;
    public GameObject readyButtonPanelObject;
    public GameObject confirmPanelObject;

    public InputField inputId;
    public InputField inputPw;
    public InputField inputNick;
    public string id;
    public string pw;
    public string nick;

    public bool inputCk = false;
    public bool idCk = false;

    public Text text;

    public string strUrl;
    public string strResult;

    public void Awake() {
        networkManager = FindObjectOfType<NetworkManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnMouseDown() {
        joinPanelObject.SetActive(true);
        loginPanelObject.SetActive(false);
        confirmPanelObject.SetActive(true);
        readyButtonPanelObject.SetActive(false);
        joinButtonPanelObject.SetActive(false);
        
        if (confirmPanelObject.GetComponent<RectTransform>().position.y > -4) {
            confirmPanelObject.transform.Translate(new Vector2(0.0f, -0.6f));
        }
    }

    public void joinOK() {
        inputId = GameObject.Find("joinPanel").transform.FindChild("joinImage").transform.FindChild("idInputField").GetComponent<InputField>();
        inputPw = GameObject.Find("joinPanel").transform.FindChild("joinImage").transform.FindChild("pwInputField").GetComponent<InputField>();
        inputNick = GameObject.Find("joinPanel").transform.FindChild("joinImage").transform.FindChild("nickInputField").GetComponent<InputField>();

        id = inputId.text;
        pw = inputPw.text;
        nick = inputNick.text;
        StartCoroutine("inputCheck");
        
        if (inputCk) {
            StartCoroutine("idCheck");
        }
        
        if (idCk) {
            StartCoroutine("joinSuccess");
        }
    }

    public void joinCancel() {
        StartCoroutine("cancel");
    }

    IEnumerator inputCheck() {
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();

        if (nick == "") {
            text.text = "닉네임을 입력해주세요!";
        }
        if (pw == "") {
            text.text = "비밀번호를 입력해주세요!";
        }
        if (id == "") {
            text.text = "아이디를 입력해주세요!";
        }
        if (id != "" && pw != "" && nick != "") {
            inputCk = true;
        }

        yield return new WaitForSeconds(0.8f);

        textPanelObject.SetActive(false);
    }

    IEnumerator idCheck() {
        //login();
        string preId = PlayerPrefs.GetString("id/" + id);
        if (preId != "") {
            preId.Substring(3, preId.Length - 3);
            Debug.Log(preId);
        }
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();
         
        if (id != preId) {
            idCk = true;
        } else {
            text.text = "아이디가 이미 존재합니다!";
        }
        yield return new WaitForSeconds(0.8f);

        textPanelObject.SetActive(false);
    }

    IEnumerator joinSuccess() {
        //join();

        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();
        text.text = "회원가입을 완료했습니다!";

        gameManager.nick = nick;
        PlayerPrefs.SetString("id/" + id, "id/" + id);
        PlayerPrefs.SetString(id + "/password/" + pw, id + "/password/" + pw);
        PlayerPrefs.SetString(id + "/Nick/" + nick, id + "/Nick/" + nick);
        PlayerPrefs.SetString("Nick", nick);
        PlayerPrefs.SetInt(id + "/Coin", 0);
        PlayerPrefs.SetInt(id + "/CurrentSkin", 0);
        PlayerPrefs.SetString(id + "/skin1", "N");
        PlayerPrefs.SetString(id + "/skin2", "N");
        PlayerPrefs.SetString(id + "/skin3", "N");
        PlayerPrefs.SetString(id + "/skin4", "N");

        yield return new WaitForSeconds(0.8f);
        
        textPanelObject.SetActive(false);
        joinPanelObject.SetActive(false);
        confirmPanelObject.SetActive(false);
        loginPanelObject.SetActive(true);
        readyButtonPanelObject.SetActive(true);
        joinButtonPanelObject.SetActive(true);
    }

    IEnumerator cancel() {
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();
        text.text = "회원가입을 취소하셨습니다.";

        yield return new WaitForSeconds(1.0f);

        loginPanelObject.SetActive(true);
        joinPanelObject.SetActive(false);
        textPanelObject.SetActive(false);
        joinButtonPanelObject.SetActive(true);
        confirmPanelObject.SetActive(false);
        readyButtonPanelObject.SetActive(true);

    }

    public void join() {
        // 요청을 보내는 URl
        strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/join/" + id + "/" + pw + "/" + nick;

        networkManager.network(strUrl);
    }

    public void login() {
        // 요청을 보내는 URl
        strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/user/" + id;

        networkManager.network(strUrl);
    }
}
