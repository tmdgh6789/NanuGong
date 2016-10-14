using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeSkin3 : MonoBehaviour {

    changeSkinScript changeSkinScript;

    public void OnMouseDown() {
        changeSkinScript = FindObjectOfType<changeSkinScript>();
        changeSkinScript.changeSkin("skin3");
    }
}

