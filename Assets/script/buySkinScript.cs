using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buySkinScript : MonoBehaviour {

    buySkin1 buyskin1;
    buySkin2 buyskin2;
    buySkin3 buyskin3;
    buySkin4 buyskin4;

    public GameObject prisonImg;
    public GameObject textPanel;
    public GameObject lackCoinObj;
    public Text lackCoinText;

    public static ModalPanel lackCoinPanel;

    public string skinNum = "";
    public string skinName = "";

    void Awake() {
        if (PlayerPrefs.GetString("skin1") == "Y") {
            prisonImg = GameObject.Find("prison1");
            prisonImg.SetActive(false);
            GameObject.Find("skin1Button").transform.FindChild("textPanel1").gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetString("skin2") == "Y") {
            prisonImg = GameObject.Find("prison2");
            prisonImg.SetActive(false);
            GameObject.Find("skin2Button").transform.FindChild("textPanel2").gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetString("skin3") == "Y") {
            prisonImg = GameObject.Find("prison3");
            prisonImg.SetActive(false);
            GameObject.Find("skin3Button").transform.FindChild("textPanel3").gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetString("skin4") == "Y") {
            prisonImg = GameObject.Find("prison4");
            prisonImg.SetActive(false);
            GameObject.Find("skin4Button").transform.FindChild("textPanel4").gameObject.SetActive(true);
        }
    }

    public void buySkinFunction(int price) {
        if (price == 3) {
            skinNum = "skin1";
            skinName = "엄마 주먹밥";
            prisonImg = GameObject.Find("prison1");
            textPanel = GameObject.Find("skin1Button").transform.FindChild("textPanel1").gameObject;
        } else if (price == 4) {
            skinNum = "skin2";
            skinName = "아빠 주먹밥";
            prisonImg = GameObject.Find("prison2");
            textPanel = GameObject.Find("skin2Button").transform.FindChild("textPanel2").gameObject;
        } else if (price == 5) {
            skinNum = "skin3";
            skinName = "오빠 주먹밥";
            prisonImg = GameObject.Find("prison3");
            textPanel = GameObject.Find("skin3Button").transform.FindChild("textPanel3").gameObject;
        } else if (price == 6) {
            skinNum = "skin4";
            skinName = "동생 주먹밥";
            prisonImg = GameObject.Find("prison4");
            textPanel = GameObject.Find("skin4Button").transform.FindChild("textPanel4").gameObject;
        }

        int myCoin = PlayerPrefs.GetInt("Coin");
        string YorN = PlayerPrefs.GetString(skinNum);

        if (myCoin >= price) {
            if (YorN == "" || YorN == "N") {
                myCoin -= price;
                prisonImg.SetActive(false);
                textPanel.SetActive(true);
                lackCoinObj.SetActive(true);
                lackCoinText.text = skinName + "을 구출하셨습니다!!";
                Invoke("hideCoinPanel", 1.0f);
                PlayerPrefs.SetString(skinNum, "Y");
                PlayerPrefs.SetInt("Coin", myCoin);
                PlayerPrefs.SetString("CurrentSkin", skinNum);
            } else {
                lackCoinObj.SetActive(true);
                lackCoinText.text = "이미 구출하신 " + skinName + "입니다.";
                Invoke("hideCoinPanel", 1.0f);
            }
        } else {
            if (YorN == "" || YorN == "N") {
                lackCoinObj.SetActive(true);
                lackCoinText.text = "도넛이 부족합니다.";
                Invoke("hideCoinPanel", 1.0f);
            } else {
                lackCoinObj.SetActive(true);
                lackCoinText.text = "이미 구출하신 " + skinName + "입니다.";
                Invoke("hideCoinPanel", 1.0f);
            }
        }
    }

    void hideCoinPanel() {
        lackCoinObj.SetActive(false);
    }
}
