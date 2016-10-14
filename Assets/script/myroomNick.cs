using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myroomNick : MonoBehaviour {
    public Text myroomnick;
    // Use this for initialization
    void Awake() {
        myroomnick.text = PlayerPrefs.GetString("Nick") + "님";
    }
}
