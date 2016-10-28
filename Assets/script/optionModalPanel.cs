using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class optionModalPanel : MonoBehaviour {

    public Button recordB;
    public Button coinB;
    public Button charactorB;
    public Button closeB;
    public GameObject optionModalPanelObject;
    public GameObject confirmModalPanelObject;

    // Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
    public void Choice(UnityAction recordResetEvent, UnityAction coinResetEvent, UnityAction charactorResetEvent, UnityAction closeEvent) {
        recordB = GameObject.Find("recordResetButton").GetComponent<Button>();
        coinB = GameObject.Find("coinResetButton").GetComponent<Button>();
        charactorB = GameObject.Find("charResetButton").GetComponent<Button>();
        closeB = GameObject.Find("closeButton").GetComponent<Button>();

        recordB.onClick.RemoveAllListeners();
        recordB.onClick.AddListener(recordResetEvent);

        coinB.onClick.RemoveAllListeners();
        coinB.onClick.AddListener(coinResetEvent);

        charactorB.onClick.RemoveAllListeners();
        charactorB.onClick.AddListener(charactorResetEvent);

        closeB.onClick.RemoveAllListeners();
        closeB.onClick.AddListener(ClosePanel);

        recordB.gameObject.SetActive(true);
        coinB.gameObject.SetActive(true);
        charactorB.gameObject.SetActive(true);
        closeB.gameObject.SetActive(true);
    }

    void ClosePanel() {
        optionModalPanelObject.SetActive(false);
    }

}
