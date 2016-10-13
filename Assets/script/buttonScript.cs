using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour {
    startScript _start;
    score _score;
    combo _combo;
    timerScript _timer;
    bonusGage _bonus;

    GameObject randomRes;
    GameObject randomBall;

    GameObject[] newBall = new GameObject[6];
    GameObject[] ball = new GameObject[8];

    public Canvas comboCanvas;

    public void button(string value) {
        _start = FindObjectOfType<startScript>();
        _score = FindObjectOfType<score>();
        _combo = FindObjectOfType<combo>();
        _timer = FindObjectOfType<timerScript>();
        _bonus = FindObjectOfType<bonusGage>();

        Sprite[] leftSpr = _start.leftSpr;
        Sprite[] rightSpr = _start.rightSpr;

        GameObject bonusBall = Resources.Load("bonus") as GameObject;
        Sprite bonusBallSpr = bonusBall.GetComponent<SpriteRenderer>().sprite;

        if (_timer.timer > 0) {
            for (int i = 0; i < 8; i++) {
                ball[i] = GameObject.Find("ball" + i + "(Clone)");
            }
            Sprite ball7Spr = ball[7].GetComponent<SpriteRenderer>().sprite;
            if (value == "left") {
                if (ball7Spr == leftSpr[0] || ball7Spr == leftSpr[1] || ball7Spr == leftSpr[2] || ball7Spr == bonusBallSpr) {
                    ButtonOk("left");
                } else {
                    ButtonNo();
                }
            } else {
                if (ball7Spr == rightSpr[0] || ball7Spr == rightSpr[1] || ball7Spr == rightSpr[2] || ball7Spr == bonusBallSpr) {
                    ButtonOk("right");
                } else {
                    ButtonNo();
                }
            }
        }
    }

    void ButtonOk(string course) {
        GameObject bonusBall = Resources.Load("bonus") as GameObject;
        Sprite bonusBallSpr = bonusBall.GetComponent<SpriteRenderer>().sprite;
        Sprite ball7Spr = ball[7].GetComponent<SpriteRenderer>().sprite;

        if (_bonus.gageValue < 105) {
            _bonus.bonus(5);
        }

        if (_score.value < 1000 || _combo.value < 3) {
            if (_bonus.gageValue == 105.0f) {
                randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                _bonus.gageValue = 0;
                _bonus.baguetteGage.size = 0;
            } else {
                randomRes = _start.startRes[Random.Range(0, 4)] as GameObject;
                randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            }
        } else if ((_score.value > 999 && _score.value < 1500) || (_combo.value > 2 && _combo.value < 10)) {
            _start.ballCreate(1, 6, -1);

            newBall[0] = _start.leftRes[0];
            newBall[1] = _start.rightRes[0];
            newBall[2] = _start.leftRes[1];
            newBall[3] = _start.rightRes[1];

            if (_bonus.gageValue == 105.0f) {
                randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                _bonus.gageValue = 0;
                _bonus.baguetteGage.size = 0;
            } else {
                randomRes = newBall[Random.Range(0, 6)];
                randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            }
        } else if ((_score.value > 1499) || (_combo.value > 9)) {
            _start.ballCreate(2, 4, 0.5f);

            newBall[0] = _start.leftRes[0];
            newBall[1] = _start.rightRes[0];
            newBall[2] = _start.leftRes[1];
            newBall[3] = _start.rightRes[1];
            newBall[4] = _start.leftRes[2];
            newBall[5] = _start.rightRes[2];

            if (_bonus.gageValue == 105.0f) {
                randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                _bonus.gageValue = 0;
                _bonus.baguetteGage.size = 0;
            } else {
                randomRes = newBall[Random.Range(0, 8)];
                randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            }
        }


        float runningTime = 0.0f;


        for (int i = 0; i < 7; i++) {
            runningTime += Time.deltaTime;
            InvokeRepeating("moveDown", 0, runningTime);
            Invoke("moveStop", runningTime * 5);
        }

        runningTime = 0;

        if (course == "left") {
            runningTime += Time.deltaTime;
            InvokeRepeating("moveLeft", 0, runningTime);
        } else if (course == "right") {
            runningTime += Time.deltaTime;
            InvokeRepeating("moveRight", 0, runningTime);
        }

        for (int i = 0; i < 8; i++) {
            ball[i].transform.localScale = new Vector2(1.1f + ((float)i / 10), 1.1f + ((float)i / 10));
            ball[i].name = "ball" + (i + 1) + "(Clone)";
            randomBall.name = "ball0(Clone)";
        }

        if (ball7Spr == bonusBallSpr) {
            _timer.timer += 5.0f;
            GameObject timeBar = GameObject.Find("timeBar");
            timeBar.transform.Translate(0.6f, 0.0f, 0.0f);
        }

        Destroy(ball[7], runningTime * 5);
        comboCanvas.GetComponent<Canvas>().enabled = true;
        _combo.value += 1;
        _score.value += 100f + (_combo.value * 0.5f);
    }

    void ButtonNo() {
        if (_bonus.gageValue > 0) {
            _bonus.bonus(-10);
        }
        comboCanvas.GetComponent<Canvas>().enabled = false;
        _combo.value = 0;
        GameObject bomb = Instantiate(Resources.Load("bomb") as GameObject, ball[7].transform.position, Quaternion.identity) as GameObject;
        bomb.transform.localScale = new Vector2(1.9f, 1.9f);
        Destroy(bomb, 0.3f);
    }

    void moveDown() {
        for (int i = 0; i < 7; i++) {
            if (i < 3) {
                ball[i].transform.Translate(0.0f, -0.03f, -i * 0.01f - 0.01f);
            } else if (i == 3) {
                ball[i].transform.Translate(0.0f, -0.035f, -i * 0.01f - 0.01f);
            } else {
                ball[i].transform.Translate(0.0f, -0.055f, -i * 0.01f - 0.01f);
            }
        }
    }

    void moveLeft() {
        ball[7].transform.Translate(-0.3f, -0.2f, 0);
    }

    void moveRight() {
        ball[7].transform.Translate(0.3f, -0.2f, 0);
    }

    void moveStop() {
        CancelInvoke();
    }
}