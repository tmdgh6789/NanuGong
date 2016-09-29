using UnityEngine;
using System.Collections;

public class startScript : MonoBehaviour {

    score _score;
    combo _combo;

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
    void Start () {
        GameObject[] res = new GameObject[6];
        int i = 0;
        for (i = 0; i < 6; i++) {
            res[i] = Resources.Load("random" + i) as GameObject;
            buttonRes.Add(res[i] as GameObject);
        }

        ballCreat(0, 6, -2.5f);

        for (i = 0; i < 8; i++) {
            startRes[0] = leftRes[0];
            startRes[1] = rightRes[0];

            if (i < 4) {
                startBall[i] = Instantiate(startRes[Random.Range(0, 2)], new Vector3(0, 0.8f - (i * 0.55f), -i - 1), Quaternion.identity) as GameObject;
            } else {
                startBall[i] = Instantiate(startRes[Random.Range(0, 2)], new Vector3(0, 1.7f - (i * 0.78f), -i - 1), Quaternion.identity) as GameObject;
            }
            if (i < 7) {
                startBall[i].transform.localScale = new Vector2(1 + (i * 0.15f), 1 + (i * 0.15f));
            } else {
                startBall[i].transform.localScale = new Vector2(1.9f, 1.9f);
            }
            startBall[i].name = "ball" + i + "(Clone)";
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
