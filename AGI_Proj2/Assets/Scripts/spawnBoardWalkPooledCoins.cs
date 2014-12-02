using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnBoardWalkPooledCoins : MonoBehaviour {
	
	public Vector3 boxPosition = new Vector3(25,0,0);
	public bool spawnCoins = true;
	
	public List<GameObject> boardwalk;
	public List<GameObject> coins;
	//	public GameObject boardPrefab;
	public GameObject coinPrefab;
	//	public List<GameObject> purse;
	public int n = 0;		//Board counter
	public int m = 0;		//Coin counter
	
	// Use this for initialization
	void Start () {
		
		// Pool of 5 boards
		//for(int i = 0; i < 5; i++){ 
		//	boardwalk.Add((GameObject)Instantiate(boardPrefab));
		//}
		
		//		for (int j = 0; j<15; j++){
		//			purse.Add(Instantiate (GameObject.Find ("Coin")));
		//		}
		
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
		float margin = board.transform.localScale.x / 10;
		
		if (spawnCoins) {
			Vector3 coinPosition = boxPosition - new Vector3 (board.transform.localScale.x / 2 + margin, -1, 0);
			
			Network.RemoveRPCsInGroup(0);
			for (int i = 0; i < amountCoins; i++) {
				coinPosition += new Vector3 (splitBoxWidth, 0, 0);
				GameObject coin = coins[m];
				coin.transform.position = coinPosition;
				coin.GetComponent<MeshRenderer>().enabled = true;
				//Object coin = Network.Instantiate (coinPrefab, coinPosition, Quaternion.identity, 0);
				//Network.Destroy (coin, 10);
				m = (m + 1) % coins.Count;
			}
		}
		
		//Random position for next box
		float ypos = Random.Range (-2.0f, 2.0f);
		boxPosition += new Vector3 (length/2 + 4,ypos,0);
		n = (n + 1) % boardwalk.Count;
	}
}
