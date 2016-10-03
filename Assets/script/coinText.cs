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
        coin.text = "" + coinValue;

        int myCoin = PlayerPrefs.GetInt("Coin");
        myCoin += coinValue;
        PlayerPrefs.SetInt("Coin", myCoin);
    }
}
