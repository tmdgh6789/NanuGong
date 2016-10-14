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
        }
    }
    
    public void changeSkin(string skinName) {

        switch (skinName) {
            case "skin1":
                skinNameText.text = "엄마 주먹밥";

                GameObject.Find("currentSkinPanel").transform.FindChild("Skin1").gameObject.SetActive(true);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin2").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin3").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin4").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                break;
            case "skin2":
                skinNameText.text = "아빠 주먹밥";

                GameObject.Find("currentSkinPanel").transform.FindChild("Skin1").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin2").gameObject.SetActive(true);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin3").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin4").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                break;
            case "skin3":
                skinNameText.text = "오빠 주먹밥";

                GameObject.Find("currentSkinPanel").transform.FindChild("Skin1").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin2").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin3").gameObject.SetActive(true);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin4").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                break;
            case "skin4":
                skinNameText.text = "동생 주먹밥";

                GameObject.Find("currentSkinPanel").transform.FindChild("Skin1").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin2").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin3").gameObject.SetActive(false);
                GameObject.Find("currentSkinPanel").transform.FindChild("Skin4").gameObject.SetActive(true);
                GameObject.Find("currentSkinPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
}
