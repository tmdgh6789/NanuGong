using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public string id;
    public string pw;
    public string nick;

    void OnApplicationQuit() {
        PlayerPrefs.SetInt(id + "/CurrentSkin", 0);
    }
}
