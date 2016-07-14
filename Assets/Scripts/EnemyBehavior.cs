using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	public GameObject laserPrefab;
	public float rof = 0.3f;// shots per sec

	private float health;
	private bool ready = false;
	private Animator anim;

	void Awake () {
		health = 100;
	}

	void Start () {
		anim = GetComponent<Animator> ();
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
		if (ready) {
			health -= damage;
			if (health <= 0) {
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
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("EnemyArrival")) {
			ready = true;
		}
		float probFire = Time.deltaTime * rof;
		if (ready && Random.value < probFire) {
			_Fire ();
		}

	}

	void _Fire() {
		Vector3 startPos = transform.position + new Vector3(0, -0.5f, 0);
		Instantiate (laserPrefab, startPos, Quaternion.identity);
	}
}
