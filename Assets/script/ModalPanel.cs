using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class ModalPanel : MonoBehaviour {

    public Text record;
    public Button yesButton;
    public Button reButton;
    public Button tenSecondsButton;
    public GameObject modalPanelObject;

    private static ModalPanel modalPanel;
    public static ModalPanel Instance() {
        if (!modalPanel) {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return modalPanel;
    }

    // Yes/No/Cancel: A string, a Yes event, a re event and tenSeconds event
    public void Choice(string record, UnityAction yesEvent, UnityAction reEvent, UnityAction tenSecondsEvent) {
        modalPanelObject.SetActive(true);
        /*
        yesButton.onClick.RemoveAllListeners();
        yesButton.onClick.AddListener(yesEvent);
        yesButton.onClick.AddListener(ClosePanel);

        reButton.onClick.RemoveAllListeners();
        reButton.onClick.AddListener(reEvent);
        reButton.onClick.AddListener(ClosePanel);

        tenSecondsButton.onClick.RemoveAllListeners();
        tenSecondsButton.onClick.AddListener(tenSecondsEvent);
        tenSecondsButton.onClick.AddListener(ClosePanel);

        yesButton.gameObject.SetActive(true);
        reButton.gameObject.SetActive(true);
        tenSecondsButton.gameObject.SetActive(true);
        */

    }

    void ClosePanel() {
        modalPanelObject.SetActive(false);
    }
}