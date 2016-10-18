using UnityEngine;
using System.Collections;

public class effectSound : MonoBehaviour {

    AudioSource esSource;

    public void esPlay() {
        esSource = GameObject.FindGameObjectWithTag("EffectSound").GetComponent<AudioSource>();
        esSource.Play();
    }
}
