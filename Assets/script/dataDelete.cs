using UnityEngine;
using System.Collections;

public class dataDelete : MonoBehaviour {
    private GameManager gameManager;

    public GameObject joinPanelObject;
    public GameObject joinButtonPanelObject;
    public GameObject loginPanelObject;
    public GameObject textPanelObject;
    public GameObject readyButtonPanelObject;
    public GameObject confirmPanelObject;

    public string id;
    void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        id = gameManager.id;
    }

    public void OnClick() {
        PlayerPrefs.DeleteAll();

        joinPanelObject.SetActive(false);
        joinButtonPanelObject.SetActive(true);
        loginPanelObject.SetActive(true);
        textPanelObject.SetActive(false);
        readyButtonPanelObject.SetActive(true);
        confirmPanelObject.SetActive(false);
        
        
        PlayerPrefs.DeleteAll();
    }
}
