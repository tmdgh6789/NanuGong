using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemStart : MonoBehaviour {
    public Toggle itemTimer;
    public Toggle itemSuper;
    public Toggle itemRevival;
    
    public int coin;
    public int readyCoin;
    
    void Update() {
        coin = PlayerPrefs.GetInt("Coin");
        readyCoin = PlayerPrefs.GetInt("ReadyCoin");

        if (coin < 5 || readyCoin < 5) {
            itemTimer.GetComponent<Toggle>().enabled = false;
        }

        if (coin < 3 || readyCoin < 3) {
            itemSuper.GetComponent<Toggle>().enabled = false;
        }

        if ((coin < 5 || readyCoin < 5 ) && PlayerPrefs.GetString("CurrentSkin") == "skin3") {
            itemRevival.GetComponent<Toggle>().enabled = false;
        }
    }
    
}
