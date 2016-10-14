using UnityEngine;
using System.Collections;

public class buySkin4 : MonoBehaviour {

    buySkinScript buySkin;

    public int charPrice = 6;

    public void OnMouseDown() {
        buySkin = FindObjectOfType<buySkinScript>();
        buySkin.buySkinFunction(charPrice);
    }
}
