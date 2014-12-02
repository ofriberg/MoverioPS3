using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject Player;

	private float playerX;
	private float playerY;
	private float playerZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerX = Player.transform.position.x;
		playerY = Player.transform.position.y;
		playerZ = Player.transform.position.z;


		gameObject.transform.position = new Vector3(playerX - 1, playerY + 1, playerZ);
	}
}
