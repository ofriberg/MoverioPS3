using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBoxes : MonoBehaviour {
	
	public GameObject box;
	Vector3 boxPosition = new Vector3(30,0,0);

	// Use this for initialization
	void Start () {
		//InvokeRepeating (Method, Time, repeatRate);
		InvokeRepeating ("SpawnBox", 1f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Spawn box x numbers in front of the player
	void SpawnBox(){
		//Instantiate (Object, Position, Rotation)
		GameObject newbox = (GameObject)Instantiate(box, boxPosition, Quaternion.identity);
		float height = Random.Range (-2.0f, 2.0f);
		boxPosition += new Vector3 (7,height,0);
	}
}
