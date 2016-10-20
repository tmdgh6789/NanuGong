using UnityEngine;
using System.Collections;

public class optionButton : MonoBehaviour {

    public optionPanelButton optionPanelButton;
    public GameObject optionPanelObj;

    public void OnClick() {
        optionPanelButton = GetComponent<optionPanelButton>();
        optionPanelObj.SetActive(true);
        optionPanelButton.Open();
    }
}
