using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnBoxes : MonoBehaviour {
	
	Vector3 boxPosition = new Vector3(25,0,0);
	public bool spawnCoins = true;

	// Use this for initialization
	void Start () {
		//InvokeRepeating (Method, Time, repeatRate);
		InvokeRepeating ("SpawnBox", 1f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Spawn box x numbers in front of the player
	void SpawnBox(){
		//create new box with random length
		GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
		float length = Random.Range (2, 10);

		box.transform.position = boxPosition;
		box.transform.localScale = new Vector3 (length, 0.1F, 2);

		//Destroy it 10 seconds after it spawns
		Destroy (box, 10);
		
		//Amount of coins put depending on X-scale of box
		int amountCoins = (int)box.transform.localScale.x / 2; 			//Max size -> 5 coins, Min --> 1 coin
		float splitBoxWidth = box.transform.localScale.x / amountCoins;
		//print ("SlitBoxWidth: " + splitBoxWidth);

		//Coin position in Left end of current box
		float margin = box.transform.localScale.x / 10;

		if (spawnCoins) {
			Vector3 coinPosition = boxPosition - new Vector3 (box.transform.localScale.x / 2 + margin, -1, 0);

			for (int i = 0; i < amountCoins; i++) {
					coinPosition += new Vector3 (splitBoxWidth, 0, 0);
					Object coin = Instantiate (GameObject.Find ("Coin"), coinPosition, Quaternion.Euler (0, 0, 0));
					Destroy (coin, 10);
			}
		}

		//Random position for next box
		float ypos = Random.Range (-2.0f, 2.0f);
		boxPosition += new Vector3 (length/2 + 4,ypos,0);
	}
}
