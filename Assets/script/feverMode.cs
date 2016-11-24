using UnityEngine;
using System.Collections;

public class feverMode : MonoBehaviour {
    
    public static void feverStart() {

        GameObject[] ball = new GameObject[8];
        Sprite[] ballSpr = new Sprite[8];

        GameObject leftBall;
        Sprite leftBallSpr;
        
        leftBall = GameObject.Find("left0(Clone)");
        leftBallSpr = leftBall.GetComponent<SpriteRenderer>().sprite;

        for (int i = 0; i < 8; i++) {
            ball[i] = GameObject.Find("ball" + i + "(Clone)");
            ballSpr[i] = ball[i].GetComponent<SpriteRenderer>().sprite;
            ballSpr[i] = leftBallSpr;
        }
 
	}
}
