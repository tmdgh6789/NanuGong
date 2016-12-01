using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemStart : MonoBehaviour {
    private GameManager gameManager;
    public Toggle itemTimer;
    public Toggle itemSuper;
    public Toggle itemRevival;

    public string id;
    public int coin;
    public int readyCoin;

    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
    }
    
    void Update() {
        coin = PlayerPrefs.GetInt(id + "/Coin");
        readyCoin = PlayerPrefs.GetInt(id + "/ReadyCoin");

        if (coin < 5 || readyCoin < 5) {
            itemTimer.GetComponent<Toggle>().enabled = false;
        }

        if (coin < 3 || readyCoin < 3) {
            itemSuper.GetComponent<Toggle>().enabled = false;
        }

        if ((coin < 5 || readyCoin < 5 ) && PlayerPrefs.GetInt(id + "/CurrentSkin") == 3) {
            itemRevival.GetComponent<Toggle>().enabled = false;
        }
    }
    
}
