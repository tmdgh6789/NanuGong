using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class nickModify : MonoBehaviour {

    public GameObject joinPanelObject;
    public GameObject modifyPanelObject;
    public GameObject textPanelObject;
    public GameObject playButtonPanelObject;
    public GameObject confirmPanelObject;

    public InputField inputName;
    public Text text;

    public string Name;
    public string userName;

    private static ModalPanel joinPanel;
    private static ModalPanel modifyPanel;
    private static ModalPanel textPanel;
    private static ModalPanel playButtonPanel;
    private static ModalPanel confirmPanel;

    public void OnMouseDown() {
        joinPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        modifyPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        textPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        playButtonPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        confirmPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        joinPanelObject.SetActive(false);
        modifyPanelObject.SetActive(true);
        confirmPanelObject.SetActive(true);
        playButtonPanelObject.SetActive(false);
        textPanelObject.SetActive(false);

        int coin = PlayerPrefs.GetInt("Coin") - 10;

        PlayerPrefs.SetInt("Coin", coin);
    }

    public void modifyOK() {
        modifyPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        textPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        playButtonPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        confirmPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        Name = inputName.text;
        
        PlayerPrefs.SetString("Nick", Name);
        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();
        text.text = "닉네임을 " + Name + "로 변경하셨습니다.";
        modifyPanelObject.SetActive(false);
        Invoke("hideAndShow", 1.0f);

    }

    public void modifyCancel() {
        modifyPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        textPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        playButtonPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        confirmPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        textPanelObject.SetActive(true);
        text = GameObject.Find("text").GetComponent<Text>();
        text.text = "닉네임 변경을 취소하셨습니다.";
        modifyPanelObject.SetActive(false);
        Invoke("hideAndShow", 1.0f);
    }

    public void hideAndShow() {
        userName = PlayerPrefs.GetString("Nick");
        text.text = userName + "님 반갑습니다.\nPLAY 버튼을 눌러주세요!";
        confirmPanelObject.SetActive(false);
        playButtonPanelObject.SetActive(true);
    }
}
