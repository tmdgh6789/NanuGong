using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	leftButtonScript _left;
	rightButtonScript _right;

	// Use this for initialization
	public void moveDown(float y, float z) {
		_left = GameObject.FindObjectOfType<leftButtonScript>();
		_right = GameObject.FindObjectOfType<rightButtonScript>();

		this.transform.Translate(0.0f, y, z);
	
	}

	public void moveLeft(float x, float y) {
		_left = GameObject.FindObjectOfType<leftButtonScript>();
		_right = GameObject.FindObjectOfType<rightButtonScript>();

		this.transform.Translate(x, y, 0.0f);

	}

	public void moveRight(float x, float y) {
		_left = GameObject.FindObjectOfType<leftButtonScript>();
		_right = GameObject.FindObjectOfType<rightButtonScript>();

		this.transform.Translate(x, y, 0.0f);

	}
}
