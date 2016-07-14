using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float mouseSensitivity = 2f;
	public float UpDownRange = 45f;
	public float LeftRightRange = 60f;
	private float rotLeftRight;
	private float rotUpDown;
	private float verticalRotation;
	private float horizontalRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//좌우 회전
		rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0f, Mathf.Clamp (rotLeftRight, -LeftRightRange, LeftRightRange), 0f);

		//상하 회전
		rotUpDown = Input.GetAxis ("Mouse Y") * mouseSensitivity;
		transform.Rotate (Mathf.Clamp (rotUpDown, -UpDownRange, UpDownRange), 0f, 0f);
	}

}