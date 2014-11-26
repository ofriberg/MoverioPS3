using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GameObject score;
	private TextMesh highscoretext;
	
	public float points;
	// Use this for initialization
	void Start () {
		points = 0;
		//InvokeRepeating ("Points", 1.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		score.GetComponent<TextMesh> ().text = points.ToString();
	}

	void Points()
	{
		//points += 5;
		//Update fuelMeter text value

	}
}
