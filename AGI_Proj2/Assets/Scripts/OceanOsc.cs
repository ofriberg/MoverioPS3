using UnityEngine;
using System.Collections;

public class OceanOsc : MonoBehaviour {
	private Vector3 startPoint;
	private Vector3 endPoint;
	public float speed = 1.0F;
	public float yPos;
	public float yNeg;

	private float xPos;
	private float zPos;
	public Transform target;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		xPos = transform.position.x;
		zPos = transform.position.z;
		startPoint = new Vector3(xPos,yPos,zPos);
		endPoint = new Vector3(xPos,yNeg,zPos);

		transform.position = Vector3.Lerp(startPoint, endPoint, (Mathf.Sin(speed * Time.time) + 1.0F)/2.0F);
	}
}
