﻿using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -50) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
