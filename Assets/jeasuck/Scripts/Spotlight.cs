using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour {

	public float duration = 60.0f;
	public KeyCode keyboard;
	private Light lt;
	public float Limit = 1.0f;

	void Start () {
		lt = GetComponent<Light> ();
		lt.intensity = 0f;
	}
		
	void Update () {
		if (duration > 0f) {
			if (Input.GetKeyDown (keyboard)) {
				if (lt.intensity == 5f)
					lt.intensity = 0f;
				else
					lt.intensity = 5f;
			}

			if (lt.intensity == 5f)
				duration -= Limit * Time.deltaTime;

		} else
			lt.intensity = 0f;
	}
}
