using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour {

	
	private int count = 0;
	public float duration = 1.0F;
	public Light lt;
    void Start() {
        /*lt = GetComponent<Light>();
        lt.type = LightType.Spot;
        timeLeft = interval;*/
    }
    void Update() {
		// float phi = Time.time / duration * 2 * Mathf.PI;
        // float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
        // lt.intensity = amplitude;
		count++;
		if (count < 300) {
			transform.Rotate(Vector3.right * 10 * Time.deltaTime );
			lt.intensity += Time.deltaTime;
			count++;
		}
		else if (count < 600 && count >= 300) {
			transform.Rotate(- Vector3.right * 10 * Time.deltaTime );
			lt.intensity -= Time.deltaTime;
			count++;
		}
		else {
			count = 0;
		}
		
		//print(Time.deltaTime);
		
        
    }
}
