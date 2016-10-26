using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class backButtonPlay : MonoBehaviour {
    public pausePanelButton pausePanelButton;
    timerMove timer;

    public GameObject pausePanelObj;

    void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
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

}