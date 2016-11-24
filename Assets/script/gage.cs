using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gage : MonoBehaviour {

    public Scrollbar baguetteGage;
    public float bGageValue = 0.0f;

    public Scrollbar cloudGage;
    public float cGageValue = 0.0f;


    public void bonus(float value) {
        bGageValue += value;
        baguetteGage.size = bGageValue / 100f;
    }

    public void Smoke(float value) {
        cGageValue += value;
        cloudGage.size = cGageValue / 100f;
    }
}