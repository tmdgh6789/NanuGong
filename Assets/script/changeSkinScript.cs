using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeSkinScript : MonoBehaviour {
    
    changeSkin1 changeSkin1;
    changeSkin2 changeSkin2;
    changeSkin3 changeSkin3;
    changeSkin4 changeSkin4;

    public Text skinNameText;

    public Text text;

    int count = 0;

    public void Awake() {
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

        if (count == 0) {
            GameObject.Find("mySkinPanel").transform.FindChild("Text").gameObject.SetActive(true);
            text.text = "보유 스킨이 없습니다.";
        } else if (count == 1) {
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace1").gameObject.SetActive(true);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace2").gameObject.SetActive(true);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace3").gameObject.SetActive(true);
        } else if (count == 2) {
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace1").gameObject.SetActive(true);
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace2").gameObject.SetActive(true);
        } else if (count == 3) {
            GameObject.Find("mySkinPanel").transform.FindChild("emptySpace1").gameObject.SetActive(true);
        }
    }
    
    public void changeSkin(string skinName) {

        switch (skinName) {
            case "skin1":
                skinNameText.text = "엄마 주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);

                PlayerPrefs.SetString("CurrentSkin", "skin1");
                break;

            case "skin2":
                skinNameText.text = "아빠 주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);

                PlayerPrefs.SetString("CurrentSkin", "skin2");
                break;

            case "skin3":
                skinNameText.text = "오빠 주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);

                PlayerPrefs.SetString("CurrentSkin", "skin3");
                break;

            case "skin4":
                skinNameText.text = "동생 주먹밥";

                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                
                PlayerPrefs.SetString("CurrentSkin", "skin4");
                break;

            default:
                Debug.Log("default");
                break;
        }
    }
}
