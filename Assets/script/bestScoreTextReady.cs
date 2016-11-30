using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bestScoreTextReady : MonoBehaviour {
    public Text bestScore;

	// Use this for initialization
	void Start () {
        bestScore = GetComponent<Text>();

        bestScore.text = "" + PlayerPrefs.GetInt("BestScore");
    }
}
