/*
This scripts recreates the Hololens Gaze function (GazeGestureManager) with a mouse click.
Useful when developing without a device at hand.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecreateGaze : MonoBehaviour {

	// Gameobject being clicked (gazed)
	public GameObject FocusedObject {get; private set;}

	// User
	public Camera camera;


	void Update () {
		// If the mouse is pressed
		if (Input.GetMouseButtonDown (0)) {
			print("mouse clicked");
			// Create a ray from the current camera to the mouse position
			Ray ray = camera.ScreenPointToRay (Input.mousePosition);
			// Create an empty RaycastHit element
			RaycastHit hit;
			// Check if the ray hits an element. If it does, store the hitted element in the hit variable.
			if (Physics.Raycast (ray, out hit)) {
				// Save that object as the FocusedObject
				FocusedObject = hit.collider.gameObject;
				//Debug.Log (FocusedObject);
				// Send a message to that gameObject
				FocusedObject.SendMessageUpwards ("OnSelect");
			} else {
				// If nothing is hit, clear the FocusedObject
				FocusedObject = null;
			}
		}

	}
}
