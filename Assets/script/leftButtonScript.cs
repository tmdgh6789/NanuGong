using UnityEngine;
using System.Collections;

public class leftButtonScript : MonoBehaviour {

    buttonScript _buttonScript;
    
    public void OnMouseDown() {
        _buttonScript = FindObjectOfType<buttonScript>();
        _buttonScript.button("left");
    }
}