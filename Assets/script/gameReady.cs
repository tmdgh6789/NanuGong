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
    public GameObject deleteAllDataObject;

    private static ModalPanel joinPanel;
    private static ModalPanel loginPanel;
    private static ModalPanel textPanel;
    private static ModalPanel confirmPanel;
    private static ModalPanel nickModifyPanel;
    private static ModalPanel deleteAllDataPanel;

    void Start() {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);

        joinPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        loginPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        textPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        confirmPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        nickModifyPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        deleteAllDataPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        userName = PlayerPrefs.GetString("Nick");

        if (userName == "") {
            joinPanelObject.SetActive(true);
            loginPanelObject.SetActive(false);
            textPanelObject.SetActive(false);
            nickModifyObject.SetActive(false);
            deleteAllDataObject.SetActive(false);
        } else {
            joinPanelObject.SetActive(false);
            textPanelObject.SetActive(true);
            text = GameObject.Find("text").GetComponent<Text>();
            text.text = userName + "님 반갑습니다.\nREADY 버튼을 눌러주세요!";
            loginPanelObject.SetActive(true);
            nickModifyObject.SetActive(true);
            deleteAllDataObject.SetActive(true);
        }
    }

    public void OnMouseDown() {
        Name = inputName.text;

        if (joinPanelObject.activeSelf == false) {
            SceneManager.LoadScene(1);
        } else {
            if (Name == "") {
                joinPanelObject.SetActive(false);
                textPanelObject.SetActive(true);
                text = GameObject.Find("text").GetComponent<Text>();
                text.text = userName + "닉네임을 입력해주세요!";
                Invoke("HideText", 0.5f);
            } else {
                PlayerPrefs.SetString("Nick", Name);
                PlayerPrefs.SetString("CurrentSkin", "default");
                SceneManager.LoadScene(1);
            }
        }
    }

    void HideText() {
        textPanelObject.SetActive(false);
    }
}