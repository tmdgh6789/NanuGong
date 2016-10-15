using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class toMyRoom : MonoBehaviour {
    public GameObject bgmObj;
    public AudioSource bgmSource;

    public void OnMouseDown() {
        bgmObj = GameObject.Find("BGM");
        bgmSource = bgmObj.GetComponent<AudioSource>();
        bgmSource.Stop();
        DontDestroyOnLoad(bgmObj);

        SceneManager.LoadScene(4);
    }
}
