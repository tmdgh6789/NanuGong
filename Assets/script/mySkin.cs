using UnityEngine;
using System.Collections;

public class mySkin : MonoBehaviour {

	// Use this for initialization
     void Start () {
        GameObject.Find("currentSkinPanel").transform.FindChild("char(default)").gameObject.SetActive(true);
    }
}
