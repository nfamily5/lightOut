using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float mouseSensitivity = 2f;
	public float UpDownRange = 45f;
	public float LeftRightRange = 60f;
	public float RayCastRange = 50f;
	public float PerceptingTime = 1f;
	public float LTL = 1f; // Light Time Limit
	public int AlreadyDead = 0;

	private float oldLTL, newLTL;
	private float rotLeftRight;
	private float rotUpDown;
	private float verticalRotation;
	private float horizontalRotation;


	// Use this for initialization
	void Start () {
		oldLTL = LTL;
	}


	// Update is called once per frame
	void Update () {
		newLTL = LTL;
		// Left-Right Rotation
		rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0f, Mathf.Clamp (rotLeftRight, -LeftRightRange, LeftRightRange), 0f);

		// Up-Down Rotation
		rotUpDown = Input.GetAxis ("Mouse Y") * mouseSensitivity;
		transform.Rotate (Mathf.Clamp (rotUpDown, -UpDownRange, UpDownRange), 0f, 0f);

		// Reaction to Specters
		Light SptLt = GameObject.FindWithTag("SpotLight").GetComponent<Spotlight>().lt;
		RaycastHit hit;

		if(Physics.Raycast(transform.position, transform.forward, out hit, RayCastRange))
		{	
			Debug.DrawRay (transform.position, transform.forward * RayCastRange, Color.yellow);

			// RayCast.Collder = Specter which need Light
			if (hit.collider.gameObject.tag == "LightOnSpecter") {
				PerceptingTime -= 1f * Time.deltaTime;
				if (SptLt.intensity == 0f && PerceptingTime < 0f)
					LTL -= 1f * Time.deltaTime;
//				else if (SptLt.intensity == 5f && PerceptingTime < 0f)
//					LTL += 1f * Time.deltaTime;
			} 

			// RayCast.Collder = Specter which don't need Light
//			else if (hit.collider.gameObject.tag == "LightOffSpecter") {
//				PerceptingTime -= 1f * Time.deltaTime;
//				if (SptLt.intensity == 5f && PerceptingTime < 0f)
//					LTL -= 1f * Time.deltaTime;
//				else if (SptLt.intensity == 0f && PerceptingTime < 0f)
//					LTL += 1f * Time.deltaTime;
//			}

			// RayCast.Collder != Specter (Caution : Unless there is no collider, it won't work)
			else {

			}
		}

		// 인지시간 및 제한시간 정상화
		if ((newLTL - oldLTL) == 0f) {
			LTL = 1f;
			if (PerceptingTime < 0f){
				PerceptingTime = 1f;
			}
		}
		oldLTL = newLTL;

		// Dead-End
		if (LTL < 0f)
			AlreadyDead = 1;

		LTL = Mathf.Clamp (LTL, -1f, 1f);
		PerceptingTime = Mathf.Clamp (PerceptingTime, -10f, 1f);
	}

}