using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resetConfirm : MonoBehaviour {
    private NetworkManager networkManager;
    private GameManager gameManager;
    optionPanelButton opb;

    public GameObject confirmObj;
    public GameObject messageObj;
    public Text record;
    public Text coin;
    public string id;

    public void Ok(string rcc) {
        opb = FindObjectOfType<optionPanelButton>();
        networkManager = FindObjectOfType<NetworkManager>();
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
        rcc = opb.rcc;
        switch (rcc) {
            case "record":
                PlayerPrefs.DeleteKey(id + "/BestScore");
                PlayerPrefs.SetInt(id + "/BestScore", 0);
                if (GameObject.Find("bestScore")) {
                    record = GameObject.Find("bestScore").GetComponent<Text>();
                    record.text = "" + PlayerPrefs.GetInt(id + "/BestScore");
                }
                confirmObj.SetActive(false);
                messageObj.SetActive(true);
                Invoke("Hide", 0.8f);
                break;

            case "coin":
                PlayerPrefs.DeleteKey(id + "/Coin");
                PlayerPrefs.DeleteKey(id + "/ReadyCoin");
                PlayerPrefs.SetInt(id + "/Coin", 0);
                coin.text = "" + PlayerPrefs.GetInt(id + "/Coin");
                confirmObj.SetActive(false);
                messageObj.SetActive(true);
                Invoke("Hide", 0.8f);
                break;

            case "char":
                PlayerPrefs.DeleteKey(id + "/CurrentSkin");
                PlayerPrefs.SetInt(id + "/CurrentSkin", 0);
                confirmObj.SetActive(false);
                messageObj.SetActive(true);
                Invoke("Hide", 0.8f);
                break;
        }
        // reset(rcc);
    }

    public void No() {
        confirmObj.SetActive(false);
    }

    public void Hide() {
        messageObj.SetActive(false);
    }

    void reset(string data) {
        data = opb.rcc;
        string strUrl;
        string id = PlayerPrefs.GetString("id");
        switch (data) {
            case "record":
                strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/resetRecord/" + id;
                networkManager.network(strUrl);
                break;
            case "coin":
                strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/resetCoin/" + id;
                networkManager.network(strUrl);
                break;
            case "char":
                strUrl = "http://nanugong.dothome.co.kr/nanugong:5000/resetChar/" + id;
                networkManager.network(strUrl);
                break;
        }
    }
}
