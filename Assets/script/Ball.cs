using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    // Use this for initialization

	public ArrayList original = new ArrayList ();
	public GameObject original1;
	public GameObject original2;
	public GameObject original3;
	public GameObject original4;
	public GameObject original5;
	public GameObject original6;

	public GameObject random;

	score _score;


    void Start () {

        GameObject[] start1 = new GameObject[2];
        GameObject[] start2 = new GameObject[2];
        GameObject[] start3 = new GameObject[2];
        GameObject[] start4 = new GameObject[2];
        GameObject[] start5 = new GameObject[2];
		GameObject[] start6 = new GameObject[2];
		GameObject[] start7 = new GameObject[2];
		GameObject[] start8 = new GameObject[2];
		GameObject[] origin1 = new GameObject[2];
		GameObject[] origin2 = new GameObject[2];

		GameObject[] origin3 = new GameObject[2];
		GameObject[] origin4 = new GameObject[2];
		GameObject[] origin5 = new GameObject[2];
		GameObject[] origin6 = new GameObject[2];

		ArrayList origin7 = new ArrayList();
		ArrayList origin8 = new ArrayList();
        
        start1[0] = Resources.Load("random1") as GameObject;
        start1[1] = Resources.Load("random2") as GameObject;

        start2[0] = Resources.Load("random1") as GameObject;
        start2[1] = Resources.Load("random2") as GameObject;

        start3[0] = Resources.Load("random1") as GameObject;
        start3[1] = Resources.Load("random2") as GameObject;

        start4[0] = Resources.Load("random1") as GameObject;
        start4[1] = Resources.Load("random2") as GameObject;

        start5[0] = Resources.Load("random1") as GameObject;
        start5[1] = Resources.Load("random2") as GameObject;

		start6[0] = Resources.Load("random1") as GameObject;
		start6[1] = Resources.Load("random2") as GameObject;

		start7[0] = Resources.Load("random1") as GameObject;
		start7[1] = Resources.Load("random2") as GameObject;

		start8[0] = Resources.Load("random1") as GameObject;
		start8[1] = Resources.Load("random2") as GameObject;

		origin1[0] = Resources.Load("soccerBall1") as GameObject;
		origin1[1] = Resources.Load("basketBall1") as GameObject;

		origin2[0] = Resources.Load("soccerBall2") as GameObject;
		origin2[1] = Resources.Load("basketBall2") as GameObject;

		origin3[0] = Resources.Load("baegu1") as GameObject;
		origin3[1] = Resources.Load("tennis1") as GameObject;

		origin4[0] = Resources.Load("baegu2") as GameObject;
		origin4[1] = Resources.Load("tennis2") as GameObject;

		origin5[0] = Resources.Load("blue1") as GameObject;
		origin5[1] = Resources.Load("purple1") as GameObject;

		origin6[0] = Resources.Load("blue2") as GameObject;
		origin6[1] = Resources.Load("purple2") as GameObject;

		origin7.Add(Resources.Load("soccerBall") as GameObject);
		origin7.Add(Resources.Load("basketBall") as GameObject);
		origin7.Add(Resources.Load("baegu") as GameObject);
		origin7.Add(Resources.Load("tennis") as GameObject);
		origin7.Add(Resources.Load("blue") as GameObject);
		origin7.Add(Resources.Load("purple") as GameObject);

		origin8.Add(Resources.Load("original0") as GameObject);
		origin8.Add(Resources.Load("original1") as GameObject);
		origin8.Add(Resources.Load("original2") as GameObject);
		origin8.Add(Resources.Load("original3") as GameObject);
		origin8.Add(Resources.Load("original4") as GameObject);
		origin8.Add(Resources.Load("original5") as GameObject);



		//original1 = Instantiate (origin7 [Random.Range(0, 6)]);
		//original1.transform.Translate (-2.0f, -3.0f, 0.0f);
		//string oname = original1.name.Remove (original1.name.Length - 7, 7);



		for (int i= 0; i < 6; i++) {
		 
			original.Add ("original" + i);
			original[i] = origin8 [Random.Range (0, 6)] as GameObject;

			for (int j = 0; j < 6; j++) {
				
				GameObject o8 = Resources.Load("original"+j.ToString()) as GameObject;

				if (original[i] == o8) {
					
					origin8.RemoveAt(j);
					Instantiate (origin8 [Random.Range (0, 5)] as GameObject);

				}


			}


			Instantiate (original [i] as GameObject);
			break;

		}

		GameObject ball1 = Instantiate(start1[Random.Range(0, 2)]);
		GameObject ball2 = Instantiate(start2[Random.Range(0, 2)]);
		GameObject ball3 = Instantiate(start3[Random.Range(0, 2)]);
		GameObject ball4 = Instantiate(start4[Random.Range(0, 2)]);
		GameObject ball5 = Instantiate(start5[Random.Range(0, 2)]);
		GameObject ball6 = Instantiate(start6[Random.Range(0, 2)]);
		GameObject ball7 = Instantiate(start7[Random.Range(0, 2)]);
		GameObject ball8 = Instantiate(start8[Random.Range(0, 2)]);

		ball1.name = "ball1(Clone)";
		ball2.name = "ball2(Clone)";
		ball3.name = "ball3(Clone)";
		ball4.name = "ball4(Clone)";
		ball5.name = "ball5(Clone)";
		ball6.name = "ball6(Clone)";
		ball7.name = "ball7(Clone)";
		ball8.name = "ball8(Clone)";

		ball1.transform.Translate(0.1f, -4.3f, -8.0f);
		ball2.transform.Translate(0.1f, -3.4f, -7.0f);
		ball3.transform.Translate(0.1f, -2.7f, -6.5f);
		ball4.transform.Translate(0.1f, -2.1f, -5.0f);
		ball5.transform.Translate(0.1f, -1.5f, -4.0f);
		ball6.transform.Translate(0.1f, -0.9f, -3.0f);
		ball7.transform.Translate(0.1f, -0.5f, -2.0f);
		ball8.transform.Translate(0.1f, -0.1f, -1.0f);

		ball1.transform.localScale = new Vector3 (2.0f, 2.0f, 0.0f);
		ball2.transform.localScale = new Vector3 (1.8f, 1.8f, 0.0f);
		ball3.transform.localScale = new Vector3 (1.6f, 1.6f, 0.0f);
		ball4.transform.localScale = new Vector3 (1.4f, 1.4f, 0.0f);
		ball5.transform.localScale = new Vector3 (1.3f, 1.3f, 0.0f);
		ball6.transform.localScale = new Vector3 (1.2f, 1.2f, 0.0f);
		ball7.transform.localScale = new Vector3 (1.1f, 1.1f, 0.0f);
		ball8.transform.localScale = new Vector3 (1.0f, 1.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update(){


	}
}
