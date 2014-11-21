using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {
	HealthMeter healthmeter; 
	public GameObject HealthBar;
	private Component spelarCollider;


	// Use this for initialization
	void Start () {
		healthmeter = HealthBar.GetComponent<HealthMeter>();
	}


	void OnCollisionEnter(Collision collision){
		healthmeter.fuel = healthmeter.fuel - 5f;
	}
	
	void OnCollisionStay(Collision collision){
		if (healthmeter.fuel != 0){
		healthmeter.fuel = healthmeter.fuel - (Time.deltaTime + 1f);
			Debug.Log (healthmeter.fuel);
		}
	}
	

}
