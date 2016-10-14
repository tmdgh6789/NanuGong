using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeSkin2 : MonoBehaviour {

    changeSkinScript changeSkinScript;

    public void OnMouseDown() {
        changeSkinScript = FindObjectOfType<changeSkinScript>();
        changeSkinScript.changeSkin("skin2");
    }
}

