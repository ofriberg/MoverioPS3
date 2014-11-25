using UnityEngine;
using System.Collections;

public class HealthMeter : MonoBehaviour {


	public GameObject fuelmeter;
	public GameObject tracking;
	public float fuel = 100f;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		//if (Input.GetKeyDown(KeyCode.Z)){
		//				fuel = fuel - 1f;
		//	Debug.Log (fuel);
		//}

		if (fuel >= 0){
			fuelmeter.transform.localScale = new Vector3 (fuel/100, 1, 1);
		}
		if (fuel <= 0){
			fuelmeter.transform.localScale = new Vector3 (0, 1, 1);
		}
	}
}