using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bestScoreTextReady : MonoBehaviour {
    private GameManager gameManager;
    public Text bestScore;

    public string id;
    // Use this for initialization
    void Start () {
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;

        bestScore = GetComponent<Text>();

        bestScore.text = "" + PlayerPrefs.GetInt(id + "/BestScore");
    }
}
