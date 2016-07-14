using UnityEngine;
using System.Collections;

public class HealthPoints : MonoBehaviour {

	public float points;
	public float newhptime;
	public float oldhptime;
	public float check;
	public float aaaaa;
	private float hptime;
	Vector3 decreaser;
	// Use this for initialization
	void Start () {
		points = 100f;
		hptime = GameObject.FindWithTag("SpotLight").GetComponent<Spotlight>().duration;
		oldhptime = hptime;
	}
	
	// Update is called once per frame
	void Update () {
		newhptime = GameObject.FindWithTag("SpotLight").GetComponent<Spotlight>().duration;
		float hpcal = oldhptime - newhptime;
		points = hpcal / hptime * aaaaa;
		check = GameObject.FindWithTag ("SpotLight").GetComponent<Spotlight> ().GetComponent<Light> ().intensity;
		if (check != 0f)
			transform.position = new Vector3(transform.position.x, transform.position.y - points, transform.position.z);
		oldhptime = newhptime;
	}
}
