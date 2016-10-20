using UnityEngine;
using System.Collections;

public class pauseButton : MonoBehaviour {
    public pausePanelButton pausePanelButton;
    timerMove timer;

    public GameObject pausePanelObj;

    public void OnClick() {
        pausePanelButton = GetComponent<pausePanelButton>();
        timer = FindObjectOfType<timerMove>();
        timer.move = false;
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
        }

        pausePanelObj.SetActive(true);
        pausePanelButton.Open();
    }
}
