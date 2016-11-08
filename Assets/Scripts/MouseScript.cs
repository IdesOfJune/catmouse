using UnityEngine;
using System.Collections;

public class MouseScript : MonoBehaviour {

	public Transform cat; 
	Vector3 directionToCat; 
	Rigidbody mouserb;  
	public float thrust = 20f; 
	float raySize = 40f; 
	public AudioSource mouseNoise; 
	// Use this for initialization
	void Start () {

		mouserb = GetComponent<Rigidbody> (); 
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		directionToCat = cat.position - transform.position;

		if (Vector3.Angle(transform.forward, directionToCat) < 165f) {

			Ray mouseRay = new Ray(transform.position, directionToCat); 
			RaycastHit mouseRayHitInfo; 

			if(Physics.Raycast(mouseRay, out mouseRayHitInfo, raySize)) {

				if (mouseRayHitInfo.collider.tag == "cat") {
					
					Debug.DrawRay (mouseRay.origin, mouseRay.direction * 50f, Color.blue); 
					Debug.Log ("cat is in range"); 

					mouserb.AddForce (-directionToCat.normalized * 1500f); //run away!! 

					//noise

					if ( mouseNoise.isPlaying == false ) {
						mouseNoise.Play();
					}

					Debug.Log ("I've run away!"); 

				

				} else {

					Debug.Log ("donut"); 

				}
		}

	}
}
}
