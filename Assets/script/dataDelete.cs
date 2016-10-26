using UnityEngine;
using System.Collections;

public class dataDelete : MonoBehaviour {

    public GameObject joinPanelObject;
    public GameObject loginPanelObject;
    public GameObject textPanelObject;
    public GameObject nickModifyObject;

    public void OnClick() {
        PlayerPrefs.DeleteAll();

        joinPanelObject.SetActive(true);
        loginPanelObject.SetActive(false);
        textPanelObject.SetActive(false);
        nickModifyObject.SetActive(false);
        
        PlayerPrefs.SetString("CurrentSkin", "default");
    }
}
