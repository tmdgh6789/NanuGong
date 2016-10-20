using UnityEngine;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class optionPanelButton : MonoBehaviour {
    private optionModalPanel optionModalPanel;

    private UnityAction recordResetAction;
    private UnityAction coinResetAction;
    private UnityAction charactorResetAction;
    private UnityAction closeAction;

    public string rcc = "";


    void Awake() {
        optionModalPanel = FindObjectOfType(typeof(optionModalPanel)) as optionModalPanel;

        recordResetAction = new UnityAction(recordResetFunction);
        coinResetAction = new UnityAction(coinResetFunction);
        charactorResetAction = new UnityAction(charctorResetFunction);
        closeAction = new UnityAction(closeFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void Open() {
        optionModalPanel.Choice(recordResetFunction, coinResetFunction, charctorResetFunction, closeFunction);
    }

    //  These are wrapped into UnityActions
    void recordResetFunction() {
        rcc = "record";
        GameObject.Find("optionPanel").transform.FindChild("confirmModalPanel").gameObject.SetActive(true);
    }

    void coinResetFunction() {
        rcc = "coin";
        GameObject.Find("optionPanel").transform.FindChild("confirmModalPanel").gameObject.SetActive(true);
    }

    void charctorResetFunction() {
        rcc = "char";
        GameObject.Find("optionPanel").transform.FindChild("confirmModalPanel").gameObject.SetActive(true);
    }

    void closeFunction() {
        Debug.Log("close");
    }
}