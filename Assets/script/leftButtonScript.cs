using UnityEngine;
using System.Collections;

public class leftButtonScript : MonoBehaviour {

    buttonScript _buttonScript;
    
    void OnMouseDown() {
        _buttonScript = FindObjectOfType<buttonScript>();
        _buttonScript.button("left");
    }
}