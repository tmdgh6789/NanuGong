using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myCoinText : MonoBehaviour {
    private GameManager gameManager;

    public Text userCoin;
    public string id;
    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
    }
    // Use this for initialization
    void Start () {
        userCoin = GetComponent<Text>();
        int myCoin = PlayerPrefs.GetInt(id + "/Coin");
        userCoin.text = "" + myCoin;
	}
}
