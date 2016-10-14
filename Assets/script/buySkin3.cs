using UnityEngine;
using System.Collections;

public class buySkin3 : MonoBehaviour {

    buySkinScript buySkin;

    public int charPrice = 5;

    public void OnMouseDown() {
        buySkin = FindObjectOfType<buySkinScript>();
        buySkin.buySkinFunction(charPrice);
    }
}
