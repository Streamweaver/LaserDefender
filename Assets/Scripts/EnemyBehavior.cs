using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public GameObject laserPrefab;
	public float rof = 0.3f;// shots per sec

	private float health;
	private bool invulnerable = false;

	void Awake () {
		health = 100;
		Debug.Log ("I'm alive!");
	}

	void OnTriggerEnter2D(Collider2D col) {
		Laser laser = col.gameObject.GetComponent<Laser> ();
		if (laser) {
			laser.Damage = AddDamage (laser.Damage);
			laser.Hit ();
		}
	}

	// Adds the damage to the ship and returns any left over damage left.
	public float AddDamage(float damage) {
		if (!invulnerable) {
			health -= damage;
			if (health <= 0) {
				Debug.Log ("I'm dead!");
				Destroy (gameObject);
				return health * -1; // return any damage exceeding the health.
			} else {
				return 0;
			}
		} else {
			return 0f;
		}
	}

	void Update() {
		float probFire = Time.deltaTime * rof;
		if (Random.value < probFire) {
			_Fire ();
		}

	}

	void _Fire() {
		Vector3 startPos = transform.position + new Vector3(0, -0.5f, 0);
		Instantiate (laserPrefab, startPos, Quaternion.identity);
	}
}
