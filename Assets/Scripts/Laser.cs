using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	public float speed = 4.0f;

	// Use this for initialization
	void Start () {
		Damage = 100f;
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public float Damage {get; set;}

	// Registers a hit destroys the gameObject if no damage left.
	public void Hit() {
		if (Damage <= 0 ){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Shredder") {
			Destroy (gameObject);
		}
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
