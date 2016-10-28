using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bestScoreTextPlay : MonoBehaviour {

    score _score;
    data _data;

    public Text bestRecord;
    public int currentScore;
    int bestScore;

	// Update is called once per frame
	void Awake () {
        _data = FindObjectOfType<data>();
        _score = FindObjectOfType<score>();
        bestRecord = GetComponent<Text>();
    }

    void Update() {
        PlayerPrefs.SetInt("currentScore", (int)_score.value);
        currentScore = PlayerPrefs.GetInt("currentScore");
        bestScore = PlayerPrefs.GetInt("BestScore");

        if (PlayerPrefs.GetInt("BestScore") == 0) {
            bestRecord.text = "" + (int)_score.value;
        } else if (PlayerPrefs.GetInt("BestScore") != 0){
            bestRecord.text = "" + bestScore;
        }

        if ((int)_score.value > bestScore) {
            PlayerPrefs.SetInt("BestScore", (int)_score.value);
            bestRecord.text = "" + (int)_score.value;
        }
    }

}
