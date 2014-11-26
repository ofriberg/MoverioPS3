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
	EnemyDamage enemydamage;
	//float speed;
	
	//POWERUPS - IDÉ: switch bools, externt powerups-script... ev. 
	bool runfaster, immortal;
	#region PRIVATE_MEMBER_VARIABLES
	
	private TrackableBehaviour mTrackableBehaviour;
	
	#endregion // PRIVATE_MEMBER_VARIABLES
	
	
	#region UNTIY_MONOBEHAVIOUR_METHODS
	
	void Start()
	{
		//IDÉ: hämta in runspeed för att ha som variabel för hastigheten när trackable=lost
		//speed = player.GetComponent<ThirdPersonCharacter>().moveSpeedMultiplier;
		
		//enemydamage = player.GetComponent<EnemyDamage> ();
		
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
		
		//RUNFASTER, borde byta trackablename sen
		if (mTrackableBehaviour.TrackableName == "rut") {
			PowerUp ("runfaster", true);
		}
		
		if(mTrackableBehaviour.TrackableName == "TestBild"){
			PowerUp("immortal", true);
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
			PowerUp ("runfaster", false);
		}
		if(mTrackableBehaviour.TrackableName == "TestBild"){
			PowerUp("immortal", false);
		}
	}
	
	void PowerUp(string power, bool powerup){
		//RUN FASTER
		if(power.Equals("runfaster") && powerup){
			poweruptext.GetComponent<TextMesh> ().text = "RUN FASTER";
			//player.GetComponent<ThirdPersonCharacter>().moveSpeedMultiplier=2;
		}
		if(power.Equals("runfaster") && !powerup){
			poweruptext.GetComponent<TextMesh> ().text = "";
			//player.GetComponent<ThirdPersonCharacter>().moveSpeedMultiplier=1;
		}
		
		//IMMORTAL
		if(power.Equals ("immortal") && powerup){
			poweruptext.GetComponent<TextMesh> ().text = "IMMORTAL";
			//enemydamage.enabled=false;
		}
		if (power.Equals ("immortal") && !powerup) {
			poweruptext.GetComponent<TextMesh> ().text = "";
			//enemydamage.enabled=true;	
		}
	}
	
	#endregion // PRIVATE_METHODS
}

