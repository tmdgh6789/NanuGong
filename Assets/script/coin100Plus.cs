using UnityEngine;
using System.Collections;

public class coin100Plus : MonoBehaviour {
    private GameManager gameManager;

    public string id;
    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
    }
    // Use this for initialization
    public void OnMouseDown() {
        PlayerPrefs.SetInt(id + "/Coin", 100);
    }
}
