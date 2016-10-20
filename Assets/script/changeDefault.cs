using UnityEngine;
using System.Collections;

public class changeDefault : MonoBehaviour {

    changeSkinScript changeSkinScript;

    public void OnMouseDown() {
        changeSkinScript = FindObjectOfType<changeSkinScript>();
        changeSkinScript.changeSkin("default");
    }
}
