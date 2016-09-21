using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
        GameObject ball1 = GameObject.Find("ball1(Clone)");
        ball1.transform.Translate(-0.1f, -0.08f, 0.0f);

        // 맨 마지막 공 삭제
        Destroy(ball1, 0.1f);
    }
}
