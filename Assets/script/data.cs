using UnityEngine;
using System.Collections;

public class data : MonoBehaviour {

    // Use this for initialization
    void Start() {
        if (PlayerPrefs.GetInt("Coin") == 0) {
            PlayerPrefs.SetInt("Coin", 0);
        }
        if (PlayerPrefs.GetInt("BestScore") == 0) {
            PlayerPrefs.SetInt("BestScore", 0);
        }
    }
}
