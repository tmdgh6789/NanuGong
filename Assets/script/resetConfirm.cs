using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class resetConfirm : MonoBehaviour {

    optionPanelButton opb;
    public GameObject confirmObj;
    public GameObject messageObj;
    public Text record;
    public Text coin;
    
    public void Ok(string rcc) {
        opb = FindObjectOfType<optionPanelButton>();
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
                PlayerPrefs.DeleteKey("skin1");
                PlayerPrefs.DeleteKey("skin2");
                PlayerPrefs.DeleteKey("skin3");
                PlayerPrefs.DeleteKey("skin4");
                PlayerPrefs.DeleteKey("CurrentSkin");
                PlayerPrefs.SetString("CurrentSkin", "default");
                confirmObj.SetActive(false);
                messageObj.SetActive(true);
                Invoke("Hide", 0.8f);
                break;
        }
    }

    public void No() {
        confirmObj.SetActive(false);
    }

    public void Hide() {
        messageObj.SetActive(false);
    }
}
