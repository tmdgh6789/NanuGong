using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class buySkinScript : MonoBehaviour {

    private NetworkManager networkManager;
    private GameManager gameManager;
    buySkin1 buyskin1;
    buySkin2 buyskin2;
    buySkin3 buyskin3;
    buySkin4 buyskin4;

    public GameObject prisonImg;
    public GameObject textPanel;
    public GameObject lackCoinObj;
    public Text lackCoinText;

    public static ModalPanel lackCoinPanel;

    public string id;
    public string skinNum = "";
    public int charNum = 0;
    public string skinName = "";
    public int myCoin;
    public int myChar;

    void Awake() {
        networkManager = FindObjectOfType<NetworkManager>();
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;

        if (PlayerPrefs.GetString(id + "/skin1") == "Y") {
            prisonImg = GameObject.Find("prison1");
            prisonImg.SetActive(false);
            GameObject.Find("skin1Button").transform.FindChild("textPanel1").gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetString(id + "/skin2") == "Y") {
            prisonImg = GameObject.Find("prison2");
            prisonImg.SetActive(false);
            GameObject.Find("skin2Button").transform.FindChild("textPanel2").gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetString(id + "/skin3") == "Y") {
            prisonImg = GameObject.Find("prison3");
            prisonImg.SetActive(false);
            GameObject.Find("skin3Button").transform.FindChild("textPanel3").gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetString(id + "/skin4") == "Y") {
            prisonImg = GameObject.Find("prison4");
            prisonImg.SetActive(false);
            GameObject.Find("skin4Button").transform.FindChild("textPanel4").gameObject.SetActive(true);
        }
    }

    public void buySkinFunction(int price) {
        AudioSource[] esSources = GameObject.FindGameObjectWithTag("EffectSound").GetComponents<AudioSource>();

        if (price == 3) {
            skinNum = "/skin1";
            charNum = 1;
            skinName = "엄마 주먹밥";
            prisonImg = GameObject.Find("prison1");
            textPanel = GameObject.Find("skin1Button").transform.FindChild("textPanel1").gameObject;
        } else if (price == 4) {
            skinNum = "/skin2";
            charNum = 2;
            skinName = "아빠 주먹밥";
            prisonImg = GameObject.Find("prison2");
            textPanel = GameObject.Find("skin2Button").transform.FindChild("textPanel2").gameObject;
        } else if (price == 5) {
            skinNum = "/skin3";
            charNum = 3;
            skinName = "오빠 주먹밥";
            prisonImg = GameObject.Find("prison3");
            textPanel = GameObject.Find("skin3Button").transform.FindChild("textPanel3").gameObject;
        } else if (price == 6) {
            skinNum = "/skin4";
            charNum = 4;
            skinName = "동생 주먹밥";
            prisonImg = GameObject.Find("prison4");
            textPanel = GameObject.Find("skin4Button").transform.FindChild("textPanel4").gameObject;
        }

        myCoin = PlayerPrefs.GetInt(id + "/Coin");
        string YorN = PlayerPrefs.GetString(id + skinNum);

        if (myCoin >= price) {
            if (YorN == "" || YorN == "N") {
                esSources[3].Play();

                myCoin -= price;
                prisonImg.SetActive(false);
                textPanel.SetActive(true);
                lackCoinObj.SetActive(true);
                lackCoinText.text = skinName + "을 구출하셨습니다!!";
                Invoke("hideCoinPanel", 1.0f);
                PlayerPrefs.SetString(id + skinNum, "Y");
                PlayerPrefs.SetInt(id + "/Coin", myCoin);
                PlayerPrefs.SetInt(id + "/CurrentSkin", charNum);
                //myRoom();
                //inventory();
            } else {
                esSources[4].Play();

                lackCoinObj.SetActive(true);
                lackCoinText.text = "이미 구출하신 " + skinName + "입니다.";
                Invoke("hideCoinPanel", 1.0f);
            }
        } else {
            esSources[4].Play();
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

    void myRoom() {
        string id = PlayerPrefs.GetString("id");
        myCoin = PlayerPrefs.GetInt("Coin");
        myChar = PlayerPrefs.GetInt("CurrentSkin");
        string strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/myRoom/" + id + "/" + myCoin + "/" + myChar;
        networkManager.network(strUrl);
    }

    void inventory() {
        string id = PlayerPrefs.GetString("id");
        string strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/buyChar/" + id + "/" + charNum;
        networkManager.network(strUrl);
    }
}
