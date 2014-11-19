using UnityEngine;
using System.Collections;

public class SpawnClouds: MonoBehaviour {

	public Transform Clouds;
	
	public float CloudSpeed;

	
	// Use this for initialization
	void Start () {
		
	}
	
	void Example(){
		int i = 0;
		while (i < 10){
			Transform transform = Instantiate(Clouds, new Vector3(i * 2f, 0, 0), Quaternion.identity) as Transform;
			i ++;
	}
	}
	// Update is called once per frame
	void Update () {

	
		}
	//	Cloud1.transform.Translate(Vector3.right * Time.deltaTime * Cloud1Speed /10);
	//	Cloud2.transform.Translate(Vector3.right * Time.deltaTime * Cloud2Speed /10);
	//	Cloud3.transform.Translate(Vector3.right * Time.deltaTime * Cloud3Speed /10);
	//	Cloud4.transform.Translate(Vector3.right * Time.deltaTime * Cloud4Speed /10);
	}

