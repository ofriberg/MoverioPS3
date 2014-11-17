using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBoxes : MonoBehaviour {
	
	Vector3 boxPosition = new Vector3(25,0,0);

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
		//create new box with random length
		GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
		box.transform.position = boxPosition;
		float length = Random.Range (2, 10);
		box.transform.localScale = new Vector3 (length, 0.1F, 2);

		//Kill it 10 seconds after it spawns
		Destroy (box, 10);

		//Random position for next box
		float height = Random.Range (-2.0f, 2.0f);
		boxPosition += new Vector3 (6,height,0);
	}
}
