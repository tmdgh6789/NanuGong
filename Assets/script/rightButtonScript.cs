using UnityEngine;
using System.Collections;

public class rightButtonScript : MonoBehaviour {

    buttonScript _buttonScript;

    public void OnMouseDown() {
        _buttonScript = FindObjectOfType<buttonScript>();
        _buttonScript.button("right");
    }
}