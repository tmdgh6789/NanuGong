using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myCoinText : MonoBehaviour {

    public Text myCoin;

    // Use this for initialization
    void Start () {
        myCoin = GetComponent<Text>();
        int haveCoin = PlayerPrefs.GetInt("Coin");
        myCoin.text = "" + haveCoin;
	}
}
