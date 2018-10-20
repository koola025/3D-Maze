using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

	// Use this for initialization

	public GameObject part;

	public List<ParticleCollisionEvent> collisionEvents;
	void Start () {
		part = GameObject.Find("Eff_Fire");
		collisionEvents = new List<ParticleCollisionEvent>();
	}

	// void OnParticleCollision(GameObject other){
	// 	int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

	// 	Rigidbody rb = other.GetComponent<Rigidbody>();
	// 	int i = 0;

	// 	while (i < numCollisionEvents){
	// 		if (rb){
	// 			other.transform.position = new Vector3(1, 0, 1);
	// 		}
	// 		i++;
	// 	}
	// 	// if(other.name == "ThirdPersonController") other.transform.position = new Vector3(1, 0, 1);
	// 	print(other.name);
	// }
	
	// Update is called once per frame
	// void Update () {
		
	// }
	void OnCollisionEnter(Collision other){
	 	//if(other.gameObject.name == "ThirdPersonController") other.gameObject.transform.position = new Vector3(1, 0, 1);
	 	print(other.gameObject.name);


		if(other.gameObject.name == "ThirdPersonController") {
			part.transform.localScale = new Vector3(5, 5, 5);
			StartCoroutine(MyFunction(other, 0.2f));
			//GameObject.Find("ThirdPersonController").GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().canMove = false;
			//other.gameObject.GetComponent<ThirdPersonCharacter>().canMove = false; // disable player controls.
		}
 	}
 
	IEnumerator MyFunction(Collision other, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		// Now do your thing here
		part.transform.localScale = new Vector3(1, 1, 1);
		other.gameObject.transform.position = new Vector3(1, 0, 1);
		
	}
	 
}
