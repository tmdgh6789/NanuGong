using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreText : MonoBehaviour {

    private score _score;

    public Text score;

	// Update is called once per frame
	void Awake () {
        _score = FindObjectOfType<score>();
        score = GetComponent<Text>();
        
        score.text = "" + (int)_score.value;
	}
}
