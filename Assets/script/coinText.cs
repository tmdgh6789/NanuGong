using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coinText : MonoBehaviour {

    private score _score;

    int coinValue;
    public Text coin;


	// Update is called once per frame
	void Awake () {
        _score = FindObjectOfType<score>();
        coin = GetComponent<Text>();
    }

    void Start () {

        coinValue = (int)(_score.value * 0.001);
        if (PlayerPrefs.GetString("CurrentSkin") == "skin2") {
            float skin2Coin = coinValue * 1.5f;
            coin.text = coinValue + "+" + ((int)skin2Coin - coinValue) + " = " + (int)skin2Coin;
        } else {
            coin.text = "" + coinValue;
        }

        int myCoin = PlayerPrefs.GetInt("Coin");
        myCoin += coinValue;
        PlayerPrefs.SetInt("Coin", myCoin);
    }
}
