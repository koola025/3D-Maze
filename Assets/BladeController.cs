using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other){
	 	//if(other.gameObject.name == "ThirdPersonController") other.gameObject.transform.position = new Vector3(1, 0, 1);
	 	print(other.gameObject.name);


		if(other.gameObject.name == "ThirdPersonController") {
			StartCoroutine(MyFunction(other, 0.2f));
		}
 	}
 
	IEnumerator MyFunction(Collision other, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		// Now do your thing here
		other.gameObject.transform.position = new Vector3(1, 0, 1);
		
	}
}
