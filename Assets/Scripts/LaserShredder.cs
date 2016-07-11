using UnityEngine;
using System.Collections;

public class LaserShredder : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		Laser laser = col.gameObject.GetComponent<Laser> ();
		if (laser) {
			laser.Damage = 0f;
			laser.Hit ();
		}
	}

}
