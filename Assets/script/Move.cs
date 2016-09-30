using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	public void moveDown(float y, float z) {

		this.transform.Translate(0.0f, y, z);
	
	}

	public void moveLeft(float x, float y) {

		this.transform.Translate(x, y, 0.0f);

	}

	public void moveRight(float x, float y) {

		this.transform.Translate(x, y, 0.0f);

	}
}
