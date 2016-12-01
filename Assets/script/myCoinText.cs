using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myCoinText : MonoBehaviour {

    public Text userCoin;

    // Use this for initialization
    void Start () {
        userCoin = GetComponent<Text>();
        int myCoin = PlayerPrefs.GetInt("Coin");
        userCoin.text = "" + myCoin;
	}
}
