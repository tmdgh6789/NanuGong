using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class deleteData : MonoBehaviour {

    public GameObject joinPanelObject;
    public GameObject loginPanelObject;
    public GameObject textPanelObject;
    public GameObject playButtonPanelObject;
    public GameObject confirmPanelObject;

    private static ModalPanel joinPanel;
    private static ModalPanel loginPanel;
    private static ModalPanel textPanel;
    private static ModalPanel playButtonPanel;
    private static ModalPanel confirmPanel;

    // Use this for initialization
    public void OnMouseDown() {
        joinPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        loginPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        textPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        playButtonPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
        confirmPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;

        PlayerPrefs.DeleteAll();

        joinPanelObject.SetActive(true);
        playButtonPanelObject.SetActive(true);
        loginPanelObject.SetActive(false);
        confirmPanelObject.SetActive(false);
        textPanelObject.SetActive(false);
    }
}
