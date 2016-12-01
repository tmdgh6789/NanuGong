using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameStart : MonoBehaviour {
    private NetworkManager networkManager;
    private GameManager gameManager;

    public GameObject bgmObj;
    public AudioSource bgmSource;

    public string id;
    public int userCoin;

    void Awake() {
        networkManager = FindObjectOfType<NetworkManager>();
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
        bgmObj = GameObject.Find("BGM");
        if (bgmObj) {
            bgmSource = bgmObj.GetComponent<AudioSource>();
            bgmSource.Play();
        }
    }

    public void OnMouseDown() {
        int readyCoin = PlayerPrefs.GetInt(id + "/ReadyCoin");
        PlayerPrefs.SetInt(id + "/Coin", readyCoin);
        //setCoin();

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
