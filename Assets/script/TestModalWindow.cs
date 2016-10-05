using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class TestModalWindow : MonoBehaviour {
    private ModalPanel modalPanel;
    private timerScript timer;

    private UnityAction myTenSecondsFunction;
    private UnityAction myYesAction;
    private UnityAction myReAction;

    void Awake() {
        modalPanel = ModalPanel.Instance();
        timer = FindObjectOfType<timerScript>();
        
        myTenSecondsFunction = new UnityAction(TestTenSecondsFunction);
        myYesAction = new UnityAction(TestYesFunction);
        myReAction = new UnityAction(TestReFunction);
    }

    //  Send to the Modal Panel to set up the Buttons and Functions to call
    public void Test() {
        modalPanel.Choice(TestTenSecondsFunction, TestYesFunction, TestReFunction);
    }

    //  These are wrapped into UnityActions
    void TestTenSecondsFunction() {
        GameObject timeBar = GameObject.Find("timeBar");
        GameObject time = GameObject.Find("time");
        timer.timer = 10.0f;
        timeBar.transform.Translate(1.0f, 0.0f, 0.0f);
        time.transform.Translate(25.0f, 0.0f, 0.0f);
    }

    void TestYesFunction() {
        SceneManager.LoadScene(1);
    }

    void TestReFunction() {
        SceneManager.LoadScene(2);
    }

}