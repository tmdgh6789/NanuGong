using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemToggle : MonoBehaviour {
    public Toggle itemTimer;
    public Toggle itemSuper;
    public Text coinText;
    public Text desText;

    public static float sec;
    public static bool super;
    public int coin;
    public int readyCoin;
    public string item = "";

    void Start() {
        coin = PlayerPrefs.GetInt("Coin");
        PlayerPrefs.SetInt("ReadyCoin", coin);
    }

    void Update() {
        readyCoin = PlayerPrefs.GetInt("ReadyCoin");
    }
    
    public void timerToggle() {
        if (PlayerPrefs.GetInt("Coin") >= 5) {
            if (itemTimer.isOn) {
                readyCoin -= 5;
                PlayerPrefs.SetInt("ReadyCoin", readyCoin);
                coinText.text = "" + readyCoin;
                desText.text = "게임 시간을 10초 늘려줍니다.";
                sec = 50.0f;
            } else {
                readyCoin += 5;
                PlayerPrefs.SetInt("ReadyCoin", readyCoin);
                coinText.text = "" + readyCoin;
                desText.text = "아이템 구매를 취소하셨습니다.";
                item = "timer";
                Invoke("buyCancel", 0.8f);
                sec = 40.0f;
            }
        } else {
            sec = 40.0f;
        }
    }

    public void superToggle() {
        if (PlayerPrefs.GetInt("Coin") >= 3) {
            if (itemSuper.isOn) {
                readyCoin -= 3;
                PlayerPrefs.SetInt("ReadyCoin", readyCoin);
                coinText.text = "" + readyCoin;
                desText.text = "처음 8개 공을 같은 공으로만 나오게합니다.";
                super = true;
            } else {
                readyCoin += 3;
                PlayerPrefs.SetInt("ReadyCoin", readyCoin);
                coinText.text = "" + readyCoin;
                desText.text = "아이템 구매를 취소하셨습니다.";
                item = "super";
                Invoke("buyCancel", 0.8f);
                super = false;
            }
        } else {
            super = false;
        }
    }
    
    public void yetItem() {
        desText.text = "아이템을 준비 중입니다.";
    }

    public void lackCoin() {
        if (itemTimer.GetComponent<Toggle>().enabled == false) {
            Debug.Log("코인 부족2");
        }
    }
    
    void buyCancel() {
        switch (item) {
            case "timer":
                desText.text = "게임 시간을 10초 늘려줍니다.";
                break;
            case "super":
                desText.text = "처음 8개 공을 같은 공으로만 나오게합니다.";
                break;
            default:
                break;
        }
    }
}