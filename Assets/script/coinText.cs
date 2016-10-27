using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coinText : MonoBehaviour {

    private score _score;

    public static int coinValue;
    public static float skin2Coin;
    public Text coin;
    
    public void setText() {
        _score = FindObjectOfType<score>();
        coin = GetComponent<Text>();

        coinValue = (int)(_score.value * 0.001);
        if (PlayerPrefs.GetString("CurrentSkin") == "skin2") {
            skin2Coin = coinValue * 1.5f;
            coin.text = coinValue + "+" + ((int)skin2Coin - coinValue) + " = " + (int)skin2Coin;
        } else {
            coin.text = "" + coinValue;
        }
    }
}
