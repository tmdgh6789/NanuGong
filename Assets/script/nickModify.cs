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
    
    public void OnMouseDown() {

        joinPanelObject.SetActive(false);
        modifyPanelObject.SetActive(false);
        confirmPanelObject.SetActive(false);
        playButtonPanelObject.SetActive(false);
        textPanelObject.SetActive(true);

        text.text = "닉네임을 수정하면 도넛 10개가 소모됩니다.";

        Invoke("textHide", 1.0f);
    }

    public void modifyOK() {
        Name = inputName.text;
        
        if (Name == "") {
            modifyPanelObject.SetActive(false);
            textPanelObject.SetActive(true);
            text.text = "닉네임을 입력해주세요.";
            Invoke("textHide", 0.8f);
        } else {
            PlayerPrefs.SetString("Nick", Name);
            textPanelObject.SetActive(true);
            text = GameObject.Find("text").GetComponent<Text>();
            text.text = "닉네임을 " + Name + "(으)로 변경하셨습니다.";
            modifyPanelObject.SetActive(false);

            int coin = PlayerPrefs.GetInt("Coin") - 10;
            PlayerPrefs.SetInt("Coin", coin);
            
            Invoke("hideAndShow", 1.0f);
        }

    }

    public void modifyCancel() {
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

    void textHide() {
        textPanelObject.SetActive(false);
        modifyPanelObject.SetActive(true);
        confirmPanelObject.SetActive(true);
    }
}
