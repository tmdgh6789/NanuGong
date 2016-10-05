using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gamePlay : MonoBehaviour {

    public InputField inputName;
    public GameObject login;
    public string Name;
    public string userName;

    void Start() {
        login = GameObject.Find("login");
        userName = PlayerPrefs.GetString("Nick");

        if (userName == null) {
            login.SetActive(true);
        } else {
            login.SetActive(false);
        }
    }

    void OnMouseDown() {
        Name = inputName.text;
        
        if(login.activeSelf == false) {
            SceneManager.LoadScene(1);
        } else {
            if (Name == "") {

            } else {
                PlayerPrefs.SetString("Nick", Name);
                SceneManager.LoadScene(1);
            }
        }
    }
}
