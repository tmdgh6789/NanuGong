using UnityEngine;
using System.Collections;

public class effectSound : MonoBehaviour {
    
    AudioSource commonClick;

    public void esPlay() {
        AudioSource[] esSources = GameObject.FindGameObjectWithTag("EffectSound").GetComponents<AudioSource>();
        commonClick = esSources[0];
        commonClick .Play();
    }
}
