using UnityEngine;
using System.Collections;

public class displayChar : MonoBehaviour {
    private GameManager gameManager;

    public string id;
    int currentSkin;

    public void Update() {
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
        currentSkin = PlayerPrefs.GetInt(id + "/CurrentSkin");
        switch (currentSkin) {
            case 1:
                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                break;
            case 2:
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                break;
            case 3:
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                break;
            case 4:
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(false);
                break;
            case 0:
                GameObject.Find("charPanel").transform.FindChild("char(default)").gameObject.SetActive(true);
                GameObject.Find("charPanel").transform.FindChild("char1").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char2").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char3").gameObject.SetActive(false);
                GameObject.Find("charPanel").transform.FindChild("char4").gameObject.SetActive(false);
                break;
        }
    }
}
