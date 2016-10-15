using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemToggle : MonoBehaviour {
    public Toggle itemTimer;
    public Toggle itemSuper;
    public Text coinText;

    public static float sec;
    public static bool super;
    public int coin;
    public int itemCoin;
    void Start() {
        coin = PlayerPrefs.GetInt("Coin");
        itemCoin = coin;
    }
    
    public void timerToggle() {
        if (PlayerPrefs.GetInt("Coin") >= 5) {
            if (itemTimer.isOn) {
                coin -= 5;
                itemCoin = coin;
                coinText.text = "" + itemCoin;
                sec = 40.0f;
            } else {
                itemCoin += 5;
                coinText.text = "" + itemCoin;
                sec = 30.0f;
            }
        } else {
            sec = 30.0f;
        }
    }

    public void superToggle() {
        if (PlayerPrefs.GetInt("Coin") >= 3) {
            if (itemSuper.isOn) {
                coin -= 3;
                itemCoin = coin;
                coinText.text = "" + itemCoin;
                super = true;
            } else {
                itemCoin += 3;
                coinText.text = "" + itemCoin;
                super = false;
            }
        } else {
            super = false;
        }
    }
    
    void itemReady() {

    }

    public void lackCoin() {
        if (itemTimer.GetComponent<Toggle>().enabled == false) {
            Debug.Log("코인 부족2");
        }
    }
}