using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class welcomeText : MonoBehaviour {
    public Text welcome;
    public CanvasRenderer welcomeObj;
	
    // Use this for initialization
	void Start () {
        welcome = GetComponent<Text>();
        welcomeObj = GetComponent<CanvasRenderer>();

        string userName = PlayerPrefs.GetString("Nick");
        if (userName == null) {
            welcome.color = new Color(0.2f, 0.2f, 0.2f, 0);
        } else {
            welcome.color = new Color(0.2f, 0.2f, 0.2f, 1);
            welcome.text = userName + "님 반갑습니다.\nPLAY 버튼을 눌러주세요!";
        }
	    
	}
}
