using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization

	float turnChance; 
	Rigidbody rbody; 
	float maxRange = 5;  
	public float speed; 

	void Start () {

		rbody = GetComponent<Rigidbody> (); 
		//turnChance = Random.Range (0, 1f);  
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		turnChance = Random.Range (0, 1f); 

		//RaycastHit hit; 

		rbody.velocity = transform.forward * speed + Physics.gravity; 

		Ray moveRay = new Ray (transform.position, transform.forward); 

		if(Physics.SphereCast(moveRay, 1f, maxRange)) {

			Debug.DrawRay (moveRay.origin, moveRay.direction * 1000f, Color.blue); 

			if (turnChance > .5f) {



				transform.Rotate (0f, 90f, 0f); 

			} else if(turnChance < .5f) {

		

				transform.Rotate (0, -90f, 0f); 
			}


		}
	
	}
}

//PSEUDO CODE 

// Movement.cs script:
//FIXED UPDATE:
//set rigidbody velocity equal to [current forward direction] * 10f + Physics.gravity
//declare a var of type Ray, called "moveRay" that starts from [current position] and goes [current forward direction]
// a spherecast is like a thick raycast... read https://docs.unity3d.com/ScriptReference/Physics.SphereCast.html
//if Physics.Spherecast with moveRay of radius 1 for distance 3 is TRUE... (if there is an obstacle in front of us...)
	//then randomly turn 90 degrees left or right (turn left or right around Y axis)