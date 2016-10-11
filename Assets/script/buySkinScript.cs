using UnityEngine;
using System.Collections;

public class buySkinScript : MonoBehaviour {

    buySkin1 buyskin1;
    buySkin2 buyskin2;
    buySkin3 buyskin3;
    buySkin4 buyskin4;

    public GameObject lackCoinObj;

    public static ModalPanel lackCoinPanel;

    public int charPrice;
    public string skinNum = "";

    public void buySkinFunction(int price) {
        lackCoinPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        charPrice = price;

        if (charPrice == 1500) {
            skinNum = "skin1";
        } else if (charPrice == 2200) {
            skinNum = "skin2";
        } else if (charPrice == 3600) {
            skinNum = "skin3";
        } else if (charPrice == 4500) {
            skinNum = "skin4";
        }

        int myCoin = PlayerPrefs.GetInt("Coin");
        string YorN = PlayerPrefs.GetString(skinNum);

        if (myCoin >= charPrice) {
            if (YorN == "Y") {
                myCoin -= charPrice;
            } else {
                lackCoinObj.SetActive(true);
                Invoke("hideCoinPanel", 0.1f);
            }
        } else {
            lackCoinObj.SetActive(true);
            Invoke("hideCoinPanel", 1.0f);
        }
        PlayerPrefs.SetInt("Coin", myCoin);
        PlayerPrefs.SetString(skinNum, "Y");
        PlayerPrefs.SetString("CurrentSkin", skinNum);
    }

    void hideCoinPanel() {
        lackCoinObj.SetActive(false);
    }
}
