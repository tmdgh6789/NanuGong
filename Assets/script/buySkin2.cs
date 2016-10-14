using UnityEngine;
using System.Collections;

public class buySkin2 : MonoBehaviour {

    buySkinScript buySkin;

    public int charPrice = 4;

    public void OnMouseDown() {
        buySkin = FindObjectOfType<buySkinScript>();
        buySkin.buySkinFunction(charPrice);
    }
}
