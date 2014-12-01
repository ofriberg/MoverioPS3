using UnityEngine;
using System.Collections;

public class syncCoin : MonoBehaviour {
	private MeshRenderer mr;

	void Start() {
		mr = gameObject.GetComponent<MeshRenderer> ();
	}
	
	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		Vector3 syncPosition = Vector3.zero;
		Quaternion syncRotation = Quaternion.identity;
		bool syncVisible = false;
		if (stream.isWriting) {
			syncPosition = gameObject.transform.position;
			syncRotation = gameObject.transform.rotation;
			syncVisible = mr.enabled;
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncRotation);
			stream.Serialize(ref syncVisible);
		} else {
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncRotation);
			stream.Serialize(ref syncVisible);
			
			gameObject.transform.position = syncPosition;
			gameObject.transform.rotation = syncRotation;
			mr.enabled = syncVisible;
		}
	}
}
