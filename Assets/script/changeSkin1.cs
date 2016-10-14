using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeSkin1 : MonoBehaviour {

    changeSkinScript changeSkinScript;

    public void OnMouseDown() {
        changeSkinScript = FindObjectOfType<changeSkinScript>();
        changeSkinScript.changeSkin("skin1");
    }
}

