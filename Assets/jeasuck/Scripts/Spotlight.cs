using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour {

	public float duration = 60.0f;
	public KeyCode keyboard;
	private Light lt;
	public float Limit = 1.0f;
	private float userIntensity;

	void Start () {
		lt = GetComponent<Light> ();

		userIntensity = lt.intensity;
	}
		
	void Update () {
		if (duration > 0f) {
			if (Input.GetKeyDown (keyboard)) {
				if (lt.intensity != 0f)
					lt.intensity = 0f;
				else
					lt.intensity = userIntensity;
			}

		
				duration -= Limit * Time.deltaTime;

		} 
		else
			lt.intensity = 0f;
	}
}
