using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class itemToggle : MonoBehaviour {
    public Toggle itemTimer;
    public Toggle itemSuper;

    public static float sec;
    public static bool super;

    public void Start() {
        itemTimer.isOn = false;
        itemSuper.isOn = false;
    }

    public void timerToggle() {
        if (PlayerPrefs.GetInt("Coin") >= 0) {
            if (itemTimer.isOn) {
                sec = 40.0f;
                int coin = PlayerPrefs.GetInt("Coin") - 10;
                PlayerPrefs.SetInt("Coin", coin);
            } else {
                sec = 30.0f;
            }
        } else {
            sec = 30.0f;
        }
    }

    public void superToggle() {
        if (PlayerPrefs.GetInt("Coin") >= 0) {
            if (itemSuper.isOn) {
                super = true;
                int coin = PlayerPrefs.GetInt("Coin") - 10;
                PlayerPrefs.SetInt("Coin", coin);
            }
        }
    }
}