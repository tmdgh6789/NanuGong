using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buySkinScript : MonoBehaviour {

    buySkin1 buyskin1;
    buySkin2 buyskin2;
    buySkin3 buyskin3;
    buySkin4 buyskin4;

    public GameObject lackCoinObj;
    public Text lackCoinText;

    public static ModalPanel lackCoinPanel;

    public string skinNum = "";
    public string skinName = "";

    public void buySkinFunction(int price) {
        lackCoinPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        if (price == 3) {
            skinNum = "skin1";
            skinName = "엄마 주먹밥";
        } else if (price == 4) {
            skinNum = "skin2";
            skinName = "아빠 주먹밥";
        } else if (price == 5) {
            skinNum = "skin3";
            skinName = "오빠 주먹밥";
        } else if (price == 6) {
            skinNum = "skin4";
            skinName = "동생 주먹밥";
        }

        int myCoin = PlayerPrefs.GetInt("Coin");
        string YorN = PlayerPrefs.GetString(skinNum);

        if (myCoin >= price) {
            if (YorN == "" || YorN == "N") {
                myCoin -= price;
                lackCoinObj.SetActive(true);
                lackCoinText.text = skinName + "스킨을 구매하셨습니다.";
                Invoke("hideCoinPanel", 1.0f);
                PlayerPrefs.SetString(skinNum, "Y");
                PlayerPrefs.SetInt("Coin", myCoin);
                PlayerPrefs.SetString("CurrentSkin", skinNum);
            } else {
                lackCoinObj.SetActive(true);
                lackCoinText.text = "이미 보유중인 스킨입니다.";
                Invoke("hideCoinPanel", 1.0f);
            }
        } else {
            if (YorN == "" || YorN == "N") {
                lackCoinObj.SetActive(true);
                lackCoinText.text = "코인이 부족합니다.";
                Invoke("hideCoinPanel", 1.0f);
            } else {
                lackCoinObj.SetActive(true);
                lackCoinText.text = "이미 보유중인 스킨입니다.";
                Invoke("hideCoinPanel", 1.0f);
            }
        }
    }

    void hideCoinPanel() {
        lackCoinObj.SetActive(false);
    }
}
