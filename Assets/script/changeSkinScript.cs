using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeSkinScript : MonoBehaviour {

    private NetworkManager networkManager;

    AudioSource commonClick;

    changeSkin1 changeSkin1;
    changeSkin2 changeSkin2;
    changeSkin3 changeSkin3;
    changeSkin4 changeSkin4;

    public Text skinNameText;
    public int skin;

    public Text text;

    int count = 0;

    public void Awake() {
        networkManager = FindObjectOfType<NetworkManager>();
        skin = PlayerPrefs.GetInt("CurrentSkin");
        switch (skin) {
            case 0:
                skinNameText.text = "주먹밥";
                break;
            case 1:
                skinNameText.text = "엄마 주먹밥";
                break;
            case 2:
                skinNameText.text = "아빠 주먹밥";
                break;
            case 3:
                skinNameText.text = "오빠 주먹밥";
                break;
            case 4:
                skinNameText.text = "동생 주먹밥";
                break;
        }
        GameObject.Find("mySkinPanel").transform.FindChild("defaultButton").gameObject.SetActive(true);
        count += 1;

        if (PlayerPrefs.GetString("skin1") == "Y") {
            GameObject.Find("mySkinPanel").transform.FindChild("skin1Button").gameObject.SetActive(true);
            count += 1;
        }

        if (PlayerPrefs.GetString("skin2") == "Y") {
            GameObject.Find("mySkinPanel").transform.FindChild("skin2Button").gameObject.SetActive(true);
            count += 1;
        }

        if (PlayerPrefs.GetString("skin3") == "Y") {
            GameObject.Find("mySkinPanel").transform.FindChild("skin3Button").gameObject.SetActive(true);
            count += 1;
        }

        if (PlayerPrefs.GetString("skin4") == "Y") {
            GameObject.Find("mySkinPanel").transform.FindChild("skin4Button").gameObject.SetActive(true);
            count += 1;
        }

        if (count == 1) {
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace1").gameObject.SetActive(false);
        } else if (count == 2) {
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace1").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace2").gameObject.SetActive(false);
        } else if (count == 3) {
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace1").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace2").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace3").gameObject.SetActive(false);
        } else if (count == 4) {
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace1").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace2").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace3").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace4").gameObject.SetActive(false);
        } else if (count == 5) {
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace1").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace2").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace3").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace4").gameObject.SetActive(false);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace5").gameObject.SetActive(false);
        }

    }
    
    public void changeSkin(string skinName) {
        AudioSource[] esSources = GameObject.FindGameObjectWithTag("EffectSound").GetComponents<AudioSource>();
        commonClick = esSources[0];
        commonClick.Play();

        switch (skinName) {
            case "default":
                skinNameText.text = "주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(true);

                PlayerPrefs.SetInt("CurrentSkin", 0);
                break;
            case "skin1":
                skinNameText.text = "엄마 주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);

                PlayerPrefs.SetInt("CurrentSkin", 1);
                setMyChar();
                break;

            case "skin2":
                skinNameText.text = "아빠 주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);

                PlayerPrefs.SetInt("CurrentSkin", 2);
                setMyChar();
                break;

            case "skin3":
                skinNameText.text = "오빠 주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);

                PlayerPrefs.SetInt("CurrentSkin", 3);
                setMyChar();
                break;

            case "skin4":
                skinNameText.text = "동생 주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                
                PlayerPrefs.SetInt("CurrentSkin", 4);
                setMyChar();
                break;

            default:
                Debug.Log("default");
                break;
        }

    }

    void setMyChar() {
        string id = PlayerPrefs.GetString("id");
        int myChar = PlayerPrefs.GetInt("CurrentSkin");
        string strUrl = "http://192.168.0.5:5000/myChar/" + id + "/" + myChar;
        networkManager.network(strUrl);
    }
}
