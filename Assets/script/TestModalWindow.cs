using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TestModalWindow : MonoBehaviour {
    private ModalPanel modalPanel;
    private DisplayManager displayManager;
    
    private UnityAction myYesAction;
    private UnityAction myNoAction;
    private UnityAction myTenSecondsFunction;

    void Awake() {
        modalPanel = ModalPanel.Instance();
        displayManager = DisplayManager.Instance();

        myYesAction = new UnityAction(TestYesFunction);
        myNoAction = new UnityAction(TestreFunction);
        myTenSecondsFunction = new UnityAction(TesttenSecondsFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void Test() {
        modalPanel.Choice("", TestYesFunction, TestreFunction, TesttenSecondsFunction);
       
    }

    //  These are wrapped into UnityActions
    void TestYesFunction() {
        displayManager.DisplayMessage("");
    }

    void TestreFunction() {
        displayManager.DisplayMessage("");
    }

    void TesttenSecondsFunction() {
        displayManager.DisplayMessage("");
    }
}