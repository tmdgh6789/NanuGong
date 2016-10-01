using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coinText : MonoBehaviour {

    private score _score;

    public Text coin;

	// Update is called once per frame
	void Awake () {
        _score = FindObjectOfType<score>();
        coin = GetComponent<Text>();

        coin.text = "" + (int)_score.value;
    }
}
