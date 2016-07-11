using UnityEngine;
using System.Collections;

public class EnemyLaser : Laser {

	// Use this for initialization
	void Start () {
		Damage = 100f;
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0, -1 * speed, 0);
	}

}
