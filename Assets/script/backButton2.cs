using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class backButton2 : MonoBehaviour {
    public GameObject bgmObj;
    public AudioSource bgmSource;

    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            bgmObj = GameObject.Find("BGM");
            bgmSource = bgmObj.GetComponent<AudioSource>();
            bgmSource.Play();
            DontDestroyOnLoad(bgmObj);

            SceneManager.LoadScene(1);
        }
    }

}