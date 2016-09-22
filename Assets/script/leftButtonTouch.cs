using UnityEngine;
using System.Collections;

public class leftButtonTouch : MonoBehaviour {


	score _score;
	combo _combo;

	
	void OnMouseDown(){  // 버튼을 MouseDown 할 때 이벤트

		_score = GameObject.FindObjectOfType<score> ();
		_combo = GameObject.FindObjectOfType<combo> ();

		//램덤으로 만들 GameObject 배열 선언
		GameObject[] tempGO = new GameObject[2];

        // 랜덤으로 사용할 리소스 설정
		tempGO[0] = Resources.Load ("random1") as GameObject;
		tempGO[1] = Resources.Load ("random2") as GameObject;

		// Hierarchy 에서 GameObject 선택
		GameObject ball1 = GameObject.Find ("ball1(Clone)");
		GameObject ball2 = GameObject.Find ("ball2(Clone)");
		GameObject ball3 = GameObject.Find ("ball3(Clone)");
		GameObject ball4 = GameObject.Find ("ball4(Clone)");
		GameObject ball5 = GameObject.Find ("ball5(Clone)");
		GameObject ball6 = GameObject.Find ("ball6(Clone)");
		GameObject ball7 = GameObject.Find ("ball7(Clone)");
		GameObject ball8 = GameObject.Find ("ball8(Clone)");


        GameObject soccerBall = GameObject.Find("soccerBall");
        GameObject basketBall = GameObject.Find("basketBall");

        Sprite soccerSpr = soccerBall.GetComponent<SpriteRenderer>().sprite;
        Sprite basketSpr = basketBall.GetComponent<SpriteRenderer>().sprite;

        Sprite spr1 = ball1.GetComponent<SpriteRenderer>().sprite;

        if (spr1 == soccerSpr) {


            // 나머지 공 애니메이션
			ball2.transform.Translate(0.0f, -0.8f, -2.2f);
			ball2.transform.localScale = new Vector3 (2.0f, 2.0f, 0.0f);

			ball3.transform.Translate(0.0f, -0.8f, -2.0f);
			ball3.transform.localScale = new Vector3 (1.8f, 1.8f, 0.0f);

			ball4.transform.Translate(0.0f, -0.5f, -1.8f);
			ball4.transform.localScale = new Vector3 (1.6f, 1.6f, 0.0f);

			ball5.transform.Translate(0.0f, -0.6f, -1.6f);
			ball5.transform.localScale = new Vector3 (1.4f, 1.4f, 0.0f);

			ball6.transform.Translate(0.0f, -0.6f, -1.4f);
			ball6.transform.localScale = new Vector3 (1.3f, 1.3f, 0.0f);

			ball7.transform.Translate(0.0f, -0.4f, -1.2f);
			ball7.transform.localScale = new Vector3 (1.2f, 1.2f, 0.0f);

			ball8.transform.Translate(0.0f, -0.4f, -1.0f);
			ball8.transform.localScale = new Vector3 (1.1f, 1.1f, 0.0f);


			// 맨 처음 공 랜덤으로 생성
			GameObject randomBall = Instantiate(tempGO[Random.Range(0, 2)]);
			randomBall.transform.localScale = new Vector3 (1.0f, 1.0f, 0.0f);
			randomBall.transform.Translate(0.1f, 0.0f,0.0f);


            // 공들 이름 변경
			randomBall.name = "ball8(Clone)";
			ball8.name = "ball7(Clone)";
			ball7.name = "ball6(Clone)";
			ball6.name = "ball5(Clone)";
			ball5.name = "ball4(Clone)";
			ball4.name = "ball3(Clone)";
			ball3.name = "ball2(Clone)";
			ball2.name = "ball1(Clone)";

            // 마지막 공 삭제

            Destroy(ball1, 0.1f);

			_combo.value += 1f;
			_score.value = _score.value + 100f + (_combo.value * 0.5f);

			}
			else {
           
			_combo.value = 0.0f;
			GameObject bomb = Instantiate(Resources.Load ("bomb") as GameObject);
			Destroy(bomb, 0.5f);


        }
    }
}