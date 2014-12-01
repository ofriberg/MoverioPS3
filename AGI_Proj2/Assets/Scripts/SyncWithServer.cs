using UnityEngine;
using System.Collections;

public class SyncWithServer : MonoBehaviour {
	
	private float syncTime = 0f;
	private float syncDelay = 0f;
	private float lastSyncTime = 0f;
	private Vector3 syncStartPos = Vector3.zero;
	private Vector3 syncEndPos = Vector3.zero;
	private Quaternion syncStartRot = Quaternion.identity;
	private Quaternion syncEndRot = Quaternion.identity;
	
	// Update is called once per frame
	void Update () {
		if (!networkView.isMine)
			SynchedMovement();
	}

	void SynchedMovement() {
		syncTime += Time.deltaTime;
		float lerpTime = syncTime / syncDelay;
		gameObject.transform.position = Vector3.Lerp (syncStartPos, syncEndPos, lerpTime);
		gameObject.transform.rotation = Quaternion.Lerp (syncStartRot, syncEndRot, lerpTime);
	}

	void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
		Vector3 syncPosition = Vector3.zero;
		Quaternion syncRotation = Quaternion.identity;
		if (stream.isWriting) {
			syncPosition = gameObject.transform.position;
			syncRotation = gameObject.transform.rotation;
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncRotation);
		} else {
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncRotation);
			
			syncTime = 0f;
			syncDelay = Time.time - lastSyncTime;
			lastSyncTime = Time.time;
			
			syncStartPos = gameObject.transform.position;
			syncEndPos = syncPosition;
			syncStartRot = gameObject.transform.rotation;
			syncEndRot = syncRotation;
		}
	}
}
