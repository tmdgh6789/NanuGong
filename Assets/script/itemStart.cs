using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class itemStart : MonoBehaviour {
    public Toggle itemTimer;
    public Toggle itemSuper;

    public static float sec;
    public static bool super;
    public int coin;
    
    void Update() {
        coin = PlayerPrefs.GetInt("Coin");

        if (coin < 5) {
            itemTimer.GetComponent<Toggle>().enabled = false;
        }

        if (coin < 3) {
            itemSuper.GetComponent<Toggle>().enabled = false;
        }
    }
    
}
