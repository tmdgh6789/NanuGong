using UnityEngine;
using System.Collections;

public class leftButtonScript : MonoBehaviour {

    startScript _start;
    score _score;
    combo _combo;
    timerScript _timer;
    Move _move;

    GameObject randomRes;
    GameObject randomBall;

    GameObject[] newBall = new GameObject[6];
    GameObject[] ball = new GameObject[8];

    public Canvas comboCanvas;

    void OnMouseDown() {
        _start = GameObject.FindObjectOfType<startScript>();
        _score = GameObject.FindObjectOfType<score>();
        _combo = GameObject.FindObjectOfType<combo>();
        _timer = GameObject.FindObjectOfType<timerScript>();
        _move = GameObject.FindObjectOfType<Move>();

        if (_timer.timer > 0) {
            for (int i = 0; i < 8; i++) {
				ball[i] = GameObject.Find("ball" + i + "(Clone)");
			}
			Sprite[] leftSpr = _start.leftSpr; 
			Sprite ball7Spr = ball[7].GetComponent<SpriteRenderer>().sprite;

			if (ball7Spr == leftSpr[0] || ball7Spr == leftSpr[1] || ball7Spr == leftSpr[2]) {
				if (_score.value < 1000 || _combo.value < 3) {
					randomRes = _start.startRes[Random.Range(0, 2)] as GameObject;
					randomBall = Instantiate(randomRes, new Vector3(0, 0.8f, -1), Quaternion.identity) as GameObject;
				} else if ((_score.value > 999 && _score.value < 1500) || (_combo.value > 2 && _combo.value < 10)) {
					_start.ballCreat(1, 4, -1);

					newBall[0] = _start.leftRes[0];
					newBall[1] = _start.rightRes[0];
					newBall[2] = _start.leftRes[1];
					newBall[3] = _start.rightRes[1];

					randomRes = newBall[Random.Range (0, 4)];
					randomBall = Instantiate(randomRes, new Vector3(0, 0.8f, -1), Quaternion.identity) as GameObject;
				} else if ((_score.value > 1499) || (_combo.value > 9)) {
					_start.ballCreat(2, 2, 0.5f);

					newBall[0] = _start.leftRes[0];
					newBall[1] = _start.rightRes[0];
					newBall[2] = _start.leftRes[1];
					newBall[3] = _start.rightRes[1];
					newBall[4] = _start.leftRes[2];
					newBall[5] = _start.rightRes[2];

					randomRes = newBall[Random.Range(0, 6)];
					randomBall = Instantiate(randomRes, new Vector3(0, 0.8f, -1), Quaternion.identity) as GameObject;

				}

                for (int i = 0; i < 8; i++) {
                    if (i < 3) {
                        ball[i].transform.Translate(0.0f, -0.55f, (-i - 1));
                    } else if (i == 3) {
                        ball[i].transform.Translate(0.0f, -0.57f, -i);
                    } else {
                        ball[i].transform.Translate(0.0f, -0.78f, -i);
                    }
                    ball[i].transform.localScale = new Vector2(1 + (i * 0.15f), 1 + (i * 0.15f));
                    ball[i].name = "ball" + (i + 1) + "(Clone)";
                    randomBall.name = "ball0(Clone)";
                }

                Destroy(ball[7], 0.1f);

                comboCanvas.GetComponent<Canvas>().enabled = true;
                _combo.value += 1;
                _score.value += 100f + (_combo.value * 0.5f);

            } else {
                comboCanvas.GetComponent<Canvas>().enabled = false;
                _combo.value = 0;
                GameObject bomb = Instantiate(Resources.Load("bomb") as GameObject, ball[7].transform.position, Quaternion.identity) as GameObject;
				Destroy(bomb, 0.3f);
			}
		} else {
		}
    }
}
