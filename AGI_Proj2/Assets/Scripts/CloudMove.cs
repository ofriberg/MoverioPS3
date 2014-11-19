using UnityEngine;
using System.Collections;

public class CloudMove: MonoBehaviour {
	
	public GameObject Cloud1;
	public GameObject Cloud2;
	public GameObject Cloud3;
	public GameObject Cloud4;

	public float Cloud1Speed;
	public float Cloud2Speed;
	public float Cloud3Speed;
	public float Cloud4Speed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Cloud1.transform.Translate(Vector3.right * Time.deltaTime * Cloud1Speed /10);
		Cloud2.transform.Translate(Vector3.right * Time.deltaTime * Cloud2Speed /10);
		Cloud3.transform.Translate(Vector3.right * Time.deltaTime * Cloud3Speed /10);
		Cloud4.transform.Translate(Vector3.right * Time.deltaTime * Cloud4Speed /10);
	}
}
