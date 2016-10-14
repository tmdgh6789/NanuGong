using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeSkin4 : MonoBehaviour {

    changeSkinScript changeSkinScript;

    public void OnMouseDown() {
        changeSkinScript = FindObjectOfType<changeSkinScript>();
        changeSkinScript.changeSkin("skin4");
    }
}

