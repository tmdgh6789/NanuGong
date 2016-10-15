using UnityEngine;
using System.Collections;

public class displayChar : MonoBehaviour {

    string currentSkin;

	public void Awake() {
        currentSkin = PlayerPrefs.GetString("CurrentSkin");

        switch (currentSkin) {
            case "skin1":
                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(true);
                break;
            case "skin2":
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(true);
                break;
            case "skin3":
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(true);
                break;
            case "skin4":
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(true);
                break;
            case "default":
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(true);
                break;
            default:
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(true);
                break;
        }
    }
}
