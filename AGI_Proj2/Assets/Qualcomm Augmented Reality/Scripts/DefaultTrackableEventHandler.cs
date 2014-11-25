/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour,
ITrackableEventHandler{
	
	public GameObject poweruptext;
	public ThirdPersonCharacter player;
	float preSetSpeed;
	#region PRIVATE_MEMBER_VARIABLES
	
	private TrackableBehaviour mTrackableBehaviour;
	
	#endregion // PRIVATE_MEMBER_VARIABLES

	
	#region UNTIY_MONOBEHAVIOUR_METHODS
	
	void Start()
	{
		//IDÉ: hämta in runspeed för att ha som variabel för hastigheten när trackable=lost
		preSetSpeed = player.GetComponent<ThirdPersonCharacter>().runspeed;
		
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	#endregion // UNTIY_MONOBEHAVIOUR_METHODS
	
	
	
	#region PUBLIC_METHODS
	
	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
	}
	
	#endregion // PUBLIC_METHODS
	
	
	
	#region PRIVATE_METHODS
	
	
	private void OnTrackingFound()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		
		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}
		
		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}
		
		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		
		//RUNFASTER, borde byta namn på trackablename sen
		if (mTrackableBehaviour.TrackableName == "rut") {
			PowerUp (0.6f);
		}

		if(mTrackableBehaviour.TrackableName == "TestBild"){
			print ("TESTBILD");
		}
	}
	
	
	private void OnTrackingLost()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		
		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}
		
		// Disable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = false;
		}
		
		//Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		if (mTrackableBehaviour.TrackableName == "rut") {
			PowerUp (preSetSpeed);
		}
	}
	
	void PowerUp(float speed){
		if(speed>preSetSpeed){
			poweruptext.GetComponent<TextMesh> ().text = "POWERUP";
		}
		if(speed==preSetSpeed){
			poweruptext.GetComponent<TextMesh> ().text = " ";
		}
		player.GetComponent<ThirdPersonCharacter>().runspeed=speed;
	}
	
	#endregion // PRIVATE_METHODS
}
