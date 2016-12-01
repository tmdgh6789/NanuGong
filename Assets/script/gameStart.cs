using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameStart : MonoBehaviour {
    private NetworkManager networkManager;

    public GameObject bgmObj;
    public AudioSource bgmSource;

    public int userCoin;

    void Awake() {
        networkManager = FindObjectOfType<NetworkManager>();
        bgmObj = GameObject.Find("BGM");
        if (bgmObj) {
            bgmSource = bgmObj.GetComponent<AudioSource>();
            bgmSource.Play();
        }
    }

    public void OnMouseDown() {
        int readyCoin = PlayerPrefs.GetInt("ReadyCoin");
        PlayerPrefs.SetInt("Coin", readyCoin);
        setCoin();

        bgmObj = GameObject.Find("BGM");
        bgmSource = bgmObj.GetComponent<AudioSource>();
        bgmSource.Stop();
        DontDestroyOnLoad(bgmObj);

        SceneManager.LoadScene(2);

    }

    void setCoin() {
        string id = PlayerPrefs.GetString("id");
        userCoin = PlayerPrefs.GetInt("Coin");
        string strUrl = "http://localhost:5000/coin/" + id + "/" + userCoin;
        networkManager.network(strUrl);
    }
}
