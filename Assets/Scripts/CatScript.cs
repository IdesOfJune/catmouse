using UnityEngine;
using System.Collections;

public class CatScript : MonoBehaviour {

	public Transform mouse; 
	Vector3 directionToMouse; 
	Rigidbody catrb;  
	public float thrust = 20f; 
	float raySize = 30f; 
	public AudioSource catNoise; 

	// Use this for initialization
	void Start () {

		catrb = GetComponent<Rigidbody> (); 
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		directionToMouse = mouse.position - transform.position;

		if (Vector3.Angle(transform.forward, directionToMouse) < 90f) {

			Ray catRay = new Ray(transform.position, directionToMouse); 
			RaycastHit catRayHitInfo; 

			if(Physics.Raycast(catRay, out catRayHitInfo, raySize)) {
				if (catRayHitInfo.collider.tag == "mouse") {
					Debug.DrawRay (catRay.origin, catRay.direction * 50f, Color.red); 


					if (catRayHitInfo.distance <= 5) {

						Debug.Log ("I'm gonna kill the mouse"); 
						catNoise.Play (); 
						mouse.gameObject.SetActive (false);  

					} else {

						catrb.AddForce (directionToMouse.normalized * 1000f); //run away!! 

						Debug.Log ("Gonna catch the mouse!"); 

					}

				} 
			}

		}
	}
}