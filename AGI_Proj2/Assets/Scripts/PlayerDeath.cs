using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	spawnBoardwalk spawnscript;

	// Use this for initialization
	void Start () {
//		System.GC.Collect();
//		System.GC.WaitForPendingFinalizers();
//		Resources.UnloadUnusedAssets ();
		spawnscript = GameObject.Find ("Spawner").GetComponent<spawnBoardwalk> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -80) 
		{
			//Application.LoadLevel(Application.loadedLevel);

			// reset position, score & next spawn-coords
			transform.position = new Vector3(0f,0f,0f);
			GetComponent<Score>().points = 0;
			spawnscript.boxPosition = new Vector3(25,0,0);

		}
	}
}
