using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;
using System.Collections;

public class login : MonoBehaviour {

    public GameObject userid;
    private string Userid;
    private string[] register = {"A","a","B","b","C","c","D","d","E","e","F","f","G","g","H","h","I","i","J","j",
                                 "K","k","L","l","M","m","N","n","O","o","P","p","Q","q","R","r","S","s","T","t",
                                 "U","u","V","v","W","w","X","x","Y","y","Z","z"};

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (userid.GetComponent<InputField>().isFocused) {

            }
        }
        Userid = userid.GetComponent<InputField>().text;
	}

    void OnMouseDown() {
        SceneManager.LoadScene(1);
    }
}
