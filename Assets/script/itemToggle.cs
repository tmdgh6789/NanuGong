using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemToggle : MonoBehaviour {
    private GameManager gameManager;
    public Toggle itemTimer;
    public Toggle itemSuper;
    public Toggle itemRevival;
    public Text coinText;
    public Text desText;

    public static float sec;
    public static bool super;
    public static bool revival;
    public static int revivalValue = 19;

    public string id;
    public int coin;
    public int readyCoin;
    public string item = "";

    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
    }

    void Start() {
        coin = PlayerPrefs.GetInt(id + "/Coin");
        PlayerPrefs.SetInt(id + "/ReadyCoin", coin);

        if (PlayerPrefs.GetInt(id + "/CurrentSkin") == 3) {
            GameObject.Find("itemPanel").transform.FindChild("itemRevivalBox").gameObject.SetActive(true);
            GameObject.Find("itemPanel").transform.FindChild("yetItem1Box").gameObject.SetActive(false);
        }
    }

    void Update() {
        readyCoin = PlayerPrefs.GetInt(id + "/ReadyCoin");
    }
    
    public void timerToggle() {
        if (PlayerPrefs.GetInt(id + "/Coin") >= 5) {
            if (itemTimer.isOn) {
                readyCoin -= 5;
                PlayerPrefs.SetInt(id + "/ReadyCoin", readyCoin);
                coinText.text = "" + readyCoin;
                desText.text = "게임 시간을 10초 늘려줍니다.";
                sec = 50.0f;
            } else {
                readyCoin += 5;
                PlayerPrefs.SetInt(id + "/ReadyCoin", readyCoin);
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
        if (PlayerPrefs.GetInt(id + "/Coin") >= 3) {
            if (itemSuper.isOn) {
                readyCoin -= 3;
                PlayerPrefs.SetInt(id + "/ReadyCoin", readyCoin);
                coinText.text = "" + readyCoin;
                desText.text = "처음 8개 공을 같은 공으로만 나오게합니다.";
                super = true;
            } else {
                readyCoin += 3;
                PlayerPrefs.SetInt(id + "/ReadyCoin", readyCoin);
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

    public void revivalToggle() {
        if (PlayerPrefs.GetInt(id + "/Coin") >= 5) {
            if (itemRevival.isOn) {
                readyCoin -= 5;
                PlayerPrefs.SetInt(id + "/ReadyCoin", readyCoin);
                coinText.text = "" + readyCoin;
                desText.text = "게임이 끝난 후 19% 확률로 부활합니다.";
                revival = true;
            } else {
                readyCoin += 5;
                PlayerPrefs.SetInt(id + "/ReadyCoin", readyCoin);
                coinText.text = "" + readyCoin;
                desText.text = "아이템 구매를 취소하셨습니다.";
                item = "revival";
                Invoke("buyCancel", 0.8f);
                revival = false;
            }
        } else {
            revival = false;
        }
    }

    public void yetItem1() {
        desText.text = "숨겨진 아이템 입니다.";
    }

    public void yetItem2() {
        desText.text = "아이템을 준비 중입니다.";
    }

    public void lackCoin() {
        if (itemTimer.GetComponent<Toggle>().enabled == false || itemSuper.GetComponent<Toggle>().enabled == false) {
            desText.text = "코인이 부족합니다.";
            Invoke("buyCancel", 0.8f);
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
            case "revival":
                desText.text = "게임이 끝난 후 19% 확률로 부활합니다.";
                break;
        }
    }
}