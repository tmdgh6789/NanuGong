using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coinText : MonoBehaviour {
    private GameManager gameManager;
    private score _score;

    public static int coinValue;
    public static float skin2Coin;
    public Text coin;
    public string id;

    public void setText() {
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
        _score = FindObjectOfType<score>();
        coin = GetComponent<Text>();

        coinValue = (int)(_score.value * 0.001);
        if (PlayerPrefs.GetInt(id + "/CurrentSkin") == 2) {
            skin2Coin = coinValue * 1.5f;
            coin.text = coinValue + "+" + ((int)skin2Coin - coinValue) + " = " + (int)skin2Coin;
        } else {
            coin.text = "" + coinValue;
        }
    }
}
