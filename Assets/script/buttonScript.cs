using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    
    AudioSource buttonTrue;
    AudioSource buttonFalse;

    public Canvas comboCanvas;
    public Animator comboAnim;
    GameObject starAnimObj;
    // GameObject[] starAnimObj = new GameObject[3];
    int starAnimNum;

    public GameObject leftButton;
    public GameObject rightButton;

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
        StartCoroutine("starAnim");

        GameObject bonusBall = Resources.Load("bonus") as GameObject;
        Sprite bonusBallSpr = bonusBall.GetComponent<SpriteRenderer>().sprite;
        Sprite ball7Spr = ball[7].GetComponent<SpriteRenderer>().sprite;

        AudioSource[] esSources = GameObject.FindGameObjectWithTag("EffectSound").GetComponents<AudioSource>();
        buttonTrue = esSources[1];
        buttonTrue.Play();

        bool level1 = (_score.value < 700) || (_combo.value < 7);
        bool level2 = (_score.value > 699 && _score.value < 1400) || (_combo.value > 6 && _combo.value < 14);
        bool level3 = (_score.value > 1399 && _score.value < 2100) || (_combo.value > 13 && _combo.value < 21);
        bool level4 = (_score.value > 2099 && _score.value < 2800) || (_combo.value > 20 && _combo.value < 28);
        bool level5 = (_score.value > 2799) || (_combo.value > 27);

        if (_bonus.gageValue < 105) {
            if (PlayerPrefs.GetString("CurrentSkin") == "skin1") {
                _bonus.bonus(8);
            } else {
                _bonus.bonus(5);
            }
        }
        
        if (level1) {
            if (_bonus.gageValue >= 105.0f) {
                randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                _bonus.gageValue = 0;
                _bonus.baguetteGage.size = 0;
            } else {
                randomRes = _start.startRes[Random.Range(0, 2)] as GameObject;
                randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            }
        } else if (level2) {
            _start.leftballCreate(1, 6, -0.1f);

            newBall[0] = _start.leftRes[0];
            newBall[1] = _start.rightRes[0];
            newBall[2] = _start.leftRes[1];

            if (_bonus.gageValue >= 105.0f) {
                randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                _bonus.gageValue = 0;
                _bonus.baguetteGage.size = 0;
            } else {
                randomRes = newBall[Random.Range(0, 3)];
                randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            }
        } else if (level3) {
            _start.rightballCreate(1, 5, -0.1f);

            newBall[0] = _start.leftRes[0];
            newBall[1] = _start.rightRes[0];
            newBall[2] = _start.leftRes[1];
            newBall[3] = _start.rightRes[1];

            if (_bonus.gageValue >= 105.0f) {
                randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                _bonus.gageValue = 0;
                _bonus.baguetteGage.size = 0;
            } else {
                randomRes = newBall[Random.Range(0, 4)];
                randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
            }
        } else if (level4) {
            if (PlayerPrefs.GetString("CurrentSkin") == "skin4") {
                newBall[0] = _start.leftRes[0];
                newBall[1] = _start.rightRes[0];
                newBall[2] = _start.leftRes[1];
                newBall[3] = _start.rightRes[1];

                if (_bonus.gageValue >= 105.0f) {
                    randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                    _bonus.gageValue = 0;
                    _bonus.baguetteGage.size = 0;
                } else {
                    randomRes = newBall[Random.Range(0, 4)];
                    randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                }
            } else {
                _start.leftballCreate(2, 4, 0.7f);

                newBall[0] = _start.leftRes[0];
                newBall[1] = _start.rightRes[0];
                newBall[2] = _start.leftRes[1];
                newBall[3] = _start.rightRes[1];
                newBall[4] = _start.leftRes[2];

                if (_bonus.gageValue >= 105.0f) {
                    randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                    _bonus.gageValue = 0;
                    _bonus.baguetteGage.size = 0;
                } else {
                    randomRes = newBall[Random.Range(0, 5)];
                    randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                }
            }
        } else if (level5) {
            if (PlayerPrefs.GetString("CurrentSkin") == "skin4") {
                newBall[0] = _start.leftRes[0];
                newBall[1] = _start.rightRes[0];
                newBall[2] = _start.leftRes[1];
                newBall[3] = _start.rightRes[1];

                if (_bonus.gageValue >= 105.0f) {
                    randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                    _bonus.gageValue = 0;
                    _bonus.baguetteGage.size = 0;
                } else {
                    randomRes = newBall[Random.Range(0, 4)];
                    randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                }
            } else {
                _start.rightballCreate(2, 3, 0.7f);

                newBall[0] = _start.leftRes[0];
                newBall[1] = _start.rightRes[0];
                newBall[2] = _start.leftRes[1];
                newBall[3] = _start.rightRes[1];
                newBall[4] = _start.leftRes[2];
                newBall[5] = _start.rightRes[2];

                if (_bonus.gageValue >= 105.0f) {
                    randomBall = Instantiate(bonusBall, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                    _bonus.gageValue = 0;
                    _bonus.baguetteGage.size = 0;
                } else {
                    randomRes = newBall[Random.Range(0, 6)];
                    randomBall = Instantiate(randomRes, new Vector3(0, 0.7f, 0), Quaternion.identity) as GameObject;
                }
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

        Destroy(ball[7], runningTime * 6);
        comboCanvas.GetComponent<Canvas>().enabled = true;
        comboAnim = GameObject.Find("comboPanel").GetComponent<Animator>();
        comboAnim.Play("comboAnim", -1, 0);
        _combo.value += 1;
        _score.value += 100f + (_combo.value * 0.5f);

    }

    void ButtonNo() {
        AudioSource[] esSources = GameObject.FindGameObjectWithTag("EffectSound").GetComponents<AudioSource>();
        buttonFalse = esSources[2];
        buttonFalse.Play();

        if (_bonus.gageValue > 0) {
            _bonus.bonus(-10);
        }
        leftButton.GetComponent<Button>().enabled = false;
        rightButton.GetComponent<Button>().enabled = false;
        Invoke("buttonActivate", 0.3f);
        comboCanvas.GetComponent<Canvas>().enabled = false;
        _combo.value = 0;
        GameObject bomb = Instantiate(Resources.Load("bomb") as GameObject, ball[7].transform.position, Quaternion.identity) as GameObject;
        bomb.transform.localScale = new Vector2(1.9f, 1.9f);
        Destroy(bomb, 0.3f);
    }

    void moveDown() {
        for (int i = 0; i < 7; i++) {

            if (i < 2) {
                ball[i].transform.Translate(0, -0.025f, -i * 0.01f - 0.01f);
            } else if (i == 2) {
                ball[i].transform.Translate(0, -0.03f, -i * 0.01f - 0.01f);
            } else if (i == 3) {
                ball[i].transform.Translate(0, -0.035f, -i * 0.01f - 0.01f);
            } else if (i < 6) {
                ball[i].transform.Translate(0, -0.045f, -i * 0.01f - 0.01f);
            } else if (i == 6) {
                ball[i].transform.Translate(0, -0.05f, -i * 0.01f - 0.01f);
            } else {
                ball[i].transform.Translate(0, -0.06f, -i * 0.01f - 0.01f);
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

    void comboEnable() {
        comboCanvas.GetComponent<Canvas>().enabled = true;
    }

    void comboCancel() {
        comboCanvas.GetComponent<Canvas>().enabled = false;
        _combo.value = 0;
    }

    void buttonActivate() {
        leftButton.GetComponent<Button>().enabled = true;
        rightButton.GetComponent<Button>().enabled = true;
    }
    
    IEnumerator starAnim() {
        starAnimObj = Instantiate(Resources.Load("star1") as GameObject);

        yield return new WaitForSeconds(2.0f);

        Destroy(starAnimObj);
        /*
        for (int i = 0; i < 3; i++) {
            starAnimObj[i] = GameObject.Find("animCanvas").transform.FindChild("starAnim" + (i + 1)).gameObject;
        }
        starAnimNum = Random.Range(0, 3);
        for (int i = 0; i < 3; i++) {
            if (starAnimObj[i].activeSelf == true) {
                StartCoroutine("deActive", i);
                break;
            }
        }
        starAnimObj[starAnimNum].SetActive(true);

        yield return new WaitForSeconds(0.5f);

        starAnimObj[starAnimNum].SetActive(false);
        */
    }

    IEnumerator deActive(int i) {
        yield return new WaitForSeconds(0.5f);
        starAnimObj.SetActive(false);
    }
}