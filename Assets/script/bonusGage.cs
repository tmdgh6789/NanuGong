using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bonusGage : MonoBehaviour {

    public Scrollbar baguetteGage;
    public float gageValue = 0.0f;

    public void bonus(float value) {
        gageValue += value;
        baguetteGage.size = gageValue / 100f;
    }
}