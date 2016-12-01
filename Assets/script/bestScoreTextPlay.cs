using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bestScoreTextPlay : MonoBehaviour {
    private GameManager gameManager;
    score _score;
    data _data;

    public Text bestRecord;
    public int currentScore;
    int bestScore;
    public string id;

    // Update is called once per frame
    void Awake () {
        _data = FindObjectOfType<data>();
        _score = FindObjectOfType<score>();
        bestRecord = GetComponent<Text>();
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
    }

    void Update() {
        PlayerPrefs.SetInt(id + "/currentScore", (int)_score.value);
        currentScore = PlayerPrefs.GetInt(id + "/currentScore");
        bestScore = PlayerPrefs.GetInt(id + "/BestScore");

        if (PlayerPrefs.GetInt(id + "/BestScore") == 0) {
            bestRecord.text = "" + (int)_score.value;
        } else if (PlayerPrefs.GetInt(id + "/BestScore") != 0){
            bestRecord.text = "" + bestScore;
        }

        if ((int)_score.value > bestScore) {
            PlayerPrefs.SetInt(id + "/BestScore", (int)_score.value);
            bestRecord.text = "" + (int)_score.value;
        }
    }

}
