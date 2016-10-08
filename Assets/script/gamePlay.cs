using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gamePlay : MonoBehaviour {

    public InputField inputName;
    public Text text;
    public string Name;
    public string userName;
    
    public GameObject joinPanelObject;
    public GameObject loginPanelObject;
    public GameObject textPanelObject;
    public GameObject confirmPanelObject;

    private static ModalPanel joinPanel;
    private static ModalPanel loginPanel;
    private static ModalPanel textPanel;
    private static ModalPanel confirmPanel;

    void Start() {
        Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);

        joinPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        loginPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        textPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        confirmPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        userName = PlayerPrefs.GetString("Nick");

        if (userName == null) {
            joinPanelObject.SetActive(true);
            loginPanelObject.SetActive(false);
            textPanelObject.SetActive(false);
        } else {
            joinPanelObject.SetActive(false);
            textPanelObject.SetActive(true);
            text = GameObject.Find("text").GetComponent<Text>();
            text.text = userName + "님 반갑습니다.\nPLAY 버튼을 눌러주세요!";
            loginPanelObject.SetActive(true);
        }
    }

    public void OnMouseDown() {
        Name = inputName.text;

        if (joinPanelObject.activeSelf == false) {
            SceneManager.LoadScene(1);
        } else {
            if (Name == "") {

            } else {
                PlayerPrefs.SetString("Nick", Name);
                SceneManager.LoadScene(1);
            }
        }
    }
}