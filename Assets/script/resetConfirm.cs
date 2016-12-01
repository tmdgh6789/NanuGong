using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resetConfirm : MonoBehaviour {
    private NetworkManager networkManager;
    optionPanelButton opb;

    public GameObject confirmObj;
    public GameObject messageObj;
    public Text record;
    public Text coin;
    
    public void Ok(string rcc) {
        opb = FindObjectOfType<optionPanelButton>();
        networkManager = FindObjectOfType<NetworkManager>();
        rcc = opb.rcc;
        switch (rcc) {
            case "record":
                PlayerPrefs.DeleteKey("BestScore");
                PlayerPrefs.SetInt("BestScore", 0);
                if (GameObject.Find("bestScore")) {
                    record = GameObject.Find("bestScore").GetComponent<Text>();
                    record.text = "" + PlayerPrefs.GetInt("BestScore");
                }
                confirmObj.SetActive(false);
                messageObj.SetActive(true);
                Invoke("Hide", 0.8f);
                break;

            case "coin":
                PlayerPrefs.DeleteKey("Coin");
                PlayerPrefs.DeleteKey("ReadyCoin");
                PlayerPrefs.SetInt("Coin", 0);
                coin.text = "" + PlayerPrefs.GetInt("Coin");
                confirmObj.SetActive(false);
                messageObj.SetActive(true);
                Invoke("Hide", 0.8f);
                break;

            case "char":
                PlayerPrefs.DeleteKey("CurrentSkin");
                PlayerPrefs.SetString("CurrentSkin", "default");
                confirmObj.SetActive(false);
                messageObj.SetActive(true);
                Invoke("Hide", 0.8f);
                break;
        }
        reset(rcc);
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
                strUrl = "http://192.168.0.5:5000/resetRecord/" + id;
                networkManager.network(strUrl);
                break;
            case "coin":
                strUrl = "http://192.168.0.5:5000/resetCoin/" + id;
                networkManager.network(strUrl);
                break;
            case "char":
                strUrl = "http://192.168.0.5:5000/resetChar/" + id;
                networkManager.network(strUrl);
                break;
        }
    }
}
