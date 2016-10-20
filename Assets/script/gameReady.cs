using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameReady : MonoBehaviour {

    public InputField inputName;
    public Text text;
    public string Name;
    public string userName;
    
    public GameObject joinPanelObject;
    public GameObject loginPanelObject;
    public GameObject textPanelObject;
    public GameObject confirmPanelObject;
    public GameObject nickModifyObject;

    public GameObject bgmObj;
    public GameObject esObj;

    void Start() {
        userName = PlayerPrefs.GetString("Nick");

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
        Name = inputName.text;
        bgmObj = GameObject.Find("BGM");
        esObj = GameObject.Find("effectSound");

        if (joinPanelObject.activeSelf == false) {
            bgmObj.GetComponent<AudioSource>().Pause();
            DontDestroyOnLoad(bgmObj);
            DontDestroyOnLoad(esObj);
            SceneManager.LoadScene(1);
        } else {
            if (Name == "") {
                joinPanelObject.SetActive(false);
                textPanelObject.SetActive(true);
                text = GameObject.Find("text").GetComponent<Text>();
                text.text = "닉네임을 입력해주세요!";
                Invoke("noNick", 0.5f);
            } else {
                PlayerPrefs.SetString("Nick", Name);
                PlayerPrefs.SetString("CurrentSkin", "default");
                PlayerPrefs.SetInt("Coin", 0);
                PlayerPrefs.SetInt("BestScore", 0);

                bgmObj.GetComponent<AudioSource>().Pause();
                DontDestroyOnLoad(bgmObj);
                DontDestroyOnLoad(esObj);
                SceneManager.LoadScene(1);
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
}