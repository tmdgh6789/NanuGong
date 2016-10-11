using UnityEngine;
using System.Collections;

public class buySkin2 : MonoBehaviour {

    buySkinScript buySkin;

    public int charPrice = 2200;

    public void OnMouseDown() {
        buySkin = FindObjectOfType<buySkinScript>();
        buySkin.buySkinFunction(charPrice);
    }
}
