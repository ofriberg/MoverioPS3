using UnityEngine;
using System.Collections;

public class SpikeDamage : MonoBehaviour {
	
	void OnTriggerEnter(Collider other){
		
		other.GetComponent<PlayerDeath> ().dead = true;
		
	}
}
