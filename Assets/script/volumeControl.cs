using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class volumeControl : MonoBehaviour {

    AudioSource common;
    AudioSource buttonTrue;
    AudioSource buttonFalse;

    public Scrollbar bgmScrollbar;
    public Scrollbar esScrollbar;

	public void bgmVolume() {
        AudioSource bgmSource;
        if (GameObject.Find("playBGM")) {
            bgmSource = GameObject.Find("playBGM").GetComponent<AudioSource>();
        } else {
            bgmSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        }

        bgmSource.volume = bgmScrollbar.value;
    }

    public void esVolume() {
        AudioSource[] esSources = GameObject.Find("effectSound").GetComponents<AudioSource>();
        common = esSources[0];
        buttonTrue = esSources[1];
        buttonFalse = esSources[2];

        common.volume = esScrollbar.value;
        buttonTrue.volume = esScrollbar.value;
        buttonFalse.volume = esScrollbar.value;
    }
}
