using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startScript : MonoBehaviour {

    score _score;
    combo _combo;

    public Canvas canvas;
    public ArrayList buttonRes = new ArrayList();
    public GameObject[] leftRes = new GameObject[3];
    public GameObject[] leftBall = new GameObject[3];
    public GameObject[] rightRes = new GameObject[3];
    public GameObject[] rightBall = new GameObject[3];
    public GameObject[] startRes = new GameObject[2];
    public GameObject[] startBall = new GameObject[8];
    public Sprite[] leftSpr = new Sprite[3];
    public Sprite[] rightSpr = new Sprite[3];

    // Use this for initialization
    void Start() {
        GameObject[] res = new GameObject[6];

        int i = 0;
        for (i = 0; i < 6; i++) {
            res[i] = Resources.Load("random" + i) as GameObject;
            buttonRes.Add(res[i] as GameObject);
        }

        ballCreat(0, 6, -2.5f);  //조건 공임

        if (itemToggle.super) {
            for (i = 0; i < 8; i++) {
                startRes[0] = leftRes[0];
                startRes[1] = rightRes[0];
                
                startBall[i] = Instantiate(startRes[0]) as GameObject;
                if (i < 4) {
                    startBall[i].transform.position = new Vector3(0, 210.0f - (130.0f + (i * 5)), -i);
                } else if (i == 4) {
                    startBall[i].transform.Translate(0, 0.0f, 0.0f);
                } else {
                    startBall[i].transform.Translate(0, 0.0f, 0.0f);
                }
                startBall[i].transform.localScale = new Vector2(1.0f + ((float)i / 10), 1.0f + ((float)i / 10));
                startBall[i].name = "ball" + i + "(Clone)";
            }
        } else {
            
            for (i = 0; i < 8; i++) {
                startRes[0] = leftRes[0];
                startRes[1] = rightRes[0];
                
                startBall[i] = Instantiate(startRes[Random.Range(0, 2)]) as GameObject;

                if (i < 2) {
                    startBall[i].transform.Translate(0, 0.7f - (i * 0.5f), -i);
                } else if (i == 2) {
                    startBall[i].transform.Translate(0, -0.2f, -i);
                } else if (i == 3) {
                    startBall[i].transform.Translate(0, -0.7f, -i);
                } else if (i < 6) {
                    startBall[i].transform.Translate(0, -0.7f - (0.6f * (i - 3)), -i);
                } else if (i == 6) {
                    startBall[i].transform.Translate(0, -2.5f, -i);
                } else {
                    startBall[i].transform.Translate(0, -3.2f, -i);
                }

                startBall[i].transform.localScale = new Vector2(1.1f + ((float)i / 10), 1.1f + ((float)i / 10));
                startBall[i].name = "ball" + i + "(Clone)";
            }
            // 위에 부분 규칙 찾아서 반복문 안으로
        }
    }


    public void ballCreat(int n, int r, float pos) {
        if (!leftBall[n]) {
            leftRes[n] = buttonRes[Random.Range(0, r)] as GameObject;
            leftBall[n] = Instantiate(leftRes[n] as GameObject, new Vector2(-2, pos), Quaternion.identity) as GameObject;
            leftSpr[n] = leftBall[n].GetComponent<SpriteRenderer>().sprite;
            leftBall[n].transform.localScale = new Vector2(2f, 2f);
            leftBall[n].name = "left" + n + "(Clone)";

            for (int i = 0; i < r; i++) {
                if (leftRes[n] == buttonRes[i] as GameObject) {
                    buttonRes.RemoveAt(i);
                    rightRes[n] = buttonRes[Random.Range(0, r - 1)] as GameObject;
                    rightBall[n] = Instantiate(rightRes[n] as GameObject, new Vector2(2, pos), Quaternion.identity) as GameObject;
                    rightSpr[n] = rightBall[n].GetComponent<SpriteRenderer>().sprite;
                    rightBall[n].name = "right" + n + "(Clone)";
                    rightBall[n].transform.localScale = new Vector2(2f, 2f);
                    for (int j = 0; j < (r - 1); j++) {
                        if (rightRes[n] == buttonRes[j] as GameObject) {
                            buttonRes.RemoveAt(j);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}