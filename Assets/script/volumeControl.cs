using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class volumeControl : MonoBehaviour {

    AudioSource bgmSource;
    public Scrollbar bgmScrollbar;

	public void bgmVolume() {
        bgmSource = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();

        bgmSource.volume = bgmScrollbar.value;
    }

    public void esVolume() {

    }
}
