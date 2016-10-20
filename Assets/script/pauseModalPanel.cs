using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class pauseModalPanel : MonoBehaviour {

    public Button replayB;
    public Button quitB;
    public Button continueB;
    public GameObject pauseModalPanelObject;
    public GameObject confirmModalPanelObject;

    // Yes/No/Cancel: A string, a Yes event, a No event and Cancel event
    public void Choice(UnityAction replayEvent, UnityAction quitEvent, UnityAction continueEvent) {
        replayB = GameObject.Find("replayButton").GetComponent<Button>();
        quitB = GameObject.Find("quitButton").GetComponent<Button>();
        continueB = GameObject.Find("continueButton").GetComponent<Button>();

        replayB.onClick.RemoveAllListeners();
        replayB.onClick.AddListener(replayEvent);
        replayB.onClick.AddListener(ClosePanel);

        quitB.onClick.RemoveAllListeners();
        quitB.onClick.AddListener(quitEvent);
        quitB.onClick.AddListener(ClosePanel);

        continueB.onClick.RemoveAllListeners();
        continueB.onClick.AddListener(continueEvent);
        continueB.onClick.AddListener(ClosePanel);

        replayB.gameObject.SetActive(true);
        quitB.gameObject.SetActive(true);
        continueB.gameObject.SetActive(true);
    }

    void ClosePanel() {
        pauseModalPanelObject.SetActive(false);
    }

}
