using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreText : MonoBehaviour {

    private score _score;

    public Text score;
    float i = 0;
    
	void Update () {
        _score = FindObjectOfType<score>();
        score = GetComponent<Text>();
        AudioSource[] esSources = GameObject.FindGameObjectWithTag("EffectSound").GetComponents<AudioSource>();

        if (i < _score.value) {
            esSources[5].Play();    // 점수 올라가는 소리
            i = i + 101;
            score.text = "" + (int)i;

        } else if (i > _score.value) {
            i = _score.value;
            score.text = "" + (int)i;
            esSources[5].Stop();
            esSources[6].Play();    // 점수에 도착하면 나는 소리
        }
    }
}
