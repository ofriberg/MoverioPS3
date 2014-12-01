using UnityEngine;
using System.Collections;

public class CollectCoin : MonoBehaviour {

	void OnTriggerEnter(Collider other){

		other.GetComponent<Score> ().points += 10;
		//Destroy (gameObject);
		gameObject.GetComponent<MeshRenderer>().enabled = false;

	}
}
