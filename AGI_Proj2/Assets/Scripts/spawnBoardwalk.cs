using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnBoardwalk : MonoBehaviour {
	
	public Vector3 boxPosition = new Vector3(25,0,0);
	public bool spawnCoins = true;
	public bool spawnSpikes = true;
	
	public List<GameObject> boardwalk;
	public int n = 0;		//Board counter

	// Use this for initialization
	void Start () {

		// Pool of 5 boards
		for(int i = 0; i < 5; i++){ 
			boardwalk.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
		}

		//InvokeRepeating (Method, Time, repeatRate);
		InvokeRepeating ("SpawnBox", 2f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	//Spawn box x numbers in front of the player
	void SpawnBox(){

		GameObject board = boardwalk [n];
		float length = Random.Range (2, 10);

		board.transform.position = boxPosition;
		board.transform.localScale = new Vector3 (length, 0.1F, 2);
		
		//Amount of coins put depending on X-scale of box
		int amountCoins = (int)board.transform.localScale.x / 2; 			//Max size -> 5 coins, Min --> 1 coin
		float splitBoxWidth = board.transform.localScale.x / amountCoins;

		//Coin position in Left end of current box
		float margin = board.transform.localScale.x / (amountCoins*2);


		// Spawn spikes if board is not too short

		if (spawnSpikes && length > 3 && Random.Range (0f,1f) > 0.5f) {
			float boardLeftEnd = boxPosition.x - board.transform.localScale.x/2;
			float randBoardPlace = Random.Range(0,board.transform.localScale.x - 1);
			Vector3 spikePosition = new Vector3(boardLeftEnd + randBoardPlace,boxPosition.y,0);

			Object spikes = Instantiate(GameObject.Find ("Spikes"), spikePosition, Quaternion.identity);
			Destroy (spikes, 7.5f);
		}
		
		if (spawnCoins) {
			Vector3 coinPosition = boxPosition - new Vector3 (board.transform.localScale.x / 2 + margin, -1, 0);
			
			for (int i = 0; i < amountCoins; i++) {
				coinPosition += new Vector3 (splitBoxWidth, 0, 0);
				Object coin = Instantiate (GameObject.Find ("Coin"), coinPosition, Quaternion.identity);
				Destroy (coin, 7.5f);
			}
		}
		
		//Random position for next box
		float ypos = Random.Range (-2.0f, 2.0f);
		boxPosition += new Vector3 (length/2 + 5,ypos,0);
		n = (n + 1) % boardwalk.Count;
	}
}
