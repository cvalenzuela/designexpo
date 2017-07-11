/*
Move and/or scale a game object to a desire position and size.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Speed of the movement
	public float speed = 1.0F;

	// Origin Position
	public Vector3 originPosition = new Vector3 (0, 0, 0);
	// Target Position
	public Vector3 targetPosition = new Vector3 (0, 0, 0);

	// Origin Rotation
	public Quaternion originRotation = Quaternion.Euler (0, 0, 0);
	// Target Rotation
	public Quaternion targetRotation = Quaternion.Euler (0,0,0);

	// Origin Scale
	public Vector3 originScale = new Vector3 (0, 0, 0);
	// Target Scale
	public Vector3 targetScale = new Vector3 (0, 0, 0);

	// Boolean to start the movement
	private bool start = false;
	// Boolean to reset the object
	private bool reset = false;

    void MoveNote()
    {
        start = true;
    }

	void Update () {
		// If start is true and the position and rotation is not the desired one, move and rotate using lerp.
		if(start){

			// Move
			transform.localPosition = Vector3.Lerp (originPosition, targetPosition, speed * Time.deltaTime);
			// Scale
			transform.localScale = Vector3.Lerp (originScale, targetScale, speed * Time.deltaTime);
			// Rotate
			transform.localRotation = Quaternion.Lerp (originRotation, targetRotation, speed * Time.deltaTime);

		}
		// If reset is true and the position and rotation is not the origin one, move and rotate using lerp.
		if(reset && transform.position != originPosition){
			// Move
			transform.position = Vector3.Lerp (transform.position, originPosition, speed * Time.deltaTime);
			// Rotate
			transform.rotation = Quaternion.Lerp (transform.rotation, originRotation, speed * Time.deltaTime );
			// Scale
			transform.localScale = Vector3.Lerp (transform.localScale, originScale, speed * Time.deltaTime);

		}
	}
}
