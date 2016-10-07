using UnityEngine;
using System.Collections;

public class rightButtonScript : MonoBehaviour {

    buttonScript _buttonScript;

    void OnMouseDown() {
        _buttonScript = FindObjectOfType<buttonScript>();
        _buttonScript.button("right");
    }
}