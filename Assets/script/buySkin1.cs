using UnityEngine;
using System.Collections;

public class buySkin1 : MonoBehaviour {

    buySkinScript buySkin;

    public int charPrice = 1500;

    public void OnMouseDown() {
        buySkin = FindObjectOfType<buySkinScript>();
        buySkin.buySkinFunction(charPrice);
    }
}
