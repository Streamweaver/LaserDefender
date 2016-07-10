using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	private float health;

	void OnTriggerEnter2D(Collider2D col) {
		Laser laser = col.gameObject.GetComponent<Laser> ();
		if (laser) {
			Debug.Log (col);
		}
	}
}
