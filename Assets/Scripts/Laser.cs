using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	public float speed = 10.0f;

	private float yMax;

	// Use this for initialization
	void Start () {
		float camDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 topMost = Camera.main.ViewportToWorldPoint (new Vector3(0,1,camDistance));
		yMax = topMost.y + 2;

		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y + 1 > yMax) {
			if (gameObject) {
				Destroy (gameObject);
			}
		}
	}
}
