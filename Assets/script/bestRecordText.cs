using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bestRecordText : MonoBehaviour {

    private score _score;

    public Text bestRecord;

	// Update is called once per frame
	void Awake () {
        _score = FindObjectOfType<score>();
        bestRecord = GetComponent<Text>();

        bestRecord.text = "" + (int)_score.value;
    }
}
