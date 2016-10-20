using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class pausePanelButton : MonoBehaviour {
    private pauseModalPanel optionModalPanel;
    timerMove timer;

    private UnityAction replayAction;
    private UnityAction quitAction;
    private UnityAction continueAction;
    
    void Awake() {
        optionModalPanel = FindObjectOfType(typeof(pauseModalPanel)) as pauseModalPanel;
        timer = FindObjectOfType<timerMove>();

        replayAction = new UnityAction(replayFunction);
        quitAction = new UnityAction(quitFunction);
        continueAction = new UnityAction(continueFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void Open() {
        optionModalPanel.Choice(replayFunction, quitFunction, continueFunction);
    }

    //  These are wrapped into UnityActions
    void replayFunction() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(2);
    }

    void quitFunction() {
        SceneManager.LoadScene(1);
    }

    void continueFunction() {
        timer.move = true;
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }
    }
}