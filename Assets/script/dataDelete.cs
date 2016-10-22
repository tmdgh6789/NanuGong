using UnityEngine;
using System.Collections;

public class dataDelete : MonoBehaviour {

	public void OnClick() {
        PlayerPrefs.DeleteAll();
    }
}
