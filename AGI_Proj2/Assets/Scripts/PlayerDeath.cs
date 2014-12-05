using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	spawnBoardWalkPooledCoins spawnscript;

	public bool dead = false;
	// Use this for initialization
	void Start () {
		spawnscript = GameObject.Find ("Spawner").GetComponent<spawnBoardWalkPooledCoins> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -80 || dead ) 
		{
			//Application.LoadLevel(Application.loadedLevel);

			// reset position, score & next spawn-coords
			transform.position = new Vector3(0f,0f,0f);
			GetComponent<Score>().points = 0;
			foreach (GameObject coin in spawnscript.coins) {
				coin.GetComponent<MeshRenderer>().enabled = false;
			}
			spawnscript.boxPosition = new Vector3(25,0,0);
			dead = false;

		}
	}
}
