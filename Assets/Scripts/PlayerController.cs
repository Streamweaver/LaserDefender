using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	public float padding = 1;
	public GameObject laserPrefab;
	public bool invulnerable = false;
	public AudioClip laserSound;
	public AudioClip deathSound;

	private float health = 100f;
	private float rof = 0.3f;
	private float xMin;
	private float xMax;

	// Use this for initialization
	void Start () {
		float camDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,camDistance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,camDistance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		MoveShip ();
		FireLasers ();
	}

	void MoveShip() {
		Vector3 moveTo = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		if (Input.GetKey (KeyCode.RightArrow)) {
			moveTo +=  Vector3.right * Time.deltaTime * speed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			moveTo +=  Vector3.left * Time.deltaTime * speed;
		}
		float newX = Mathf.Clamp (moveTo.x, xMin, xMax);
		transform.position = new Vector3(newX, moveTo.y, moveTo.z);
	}

	void FireLasers() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating ("_Fire", 0.0000001f, rof);
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke ("_Fire");
		}
	}

	void _Fire() {
		Laser laser = Instantiate (laserPrefab, transform.position, Quaternion.identity) as Laser;
		AudioSource.PlayClipAtPoint (laserSound, transform.position);
	}

	// Adds the damage to the ship and returns any left over damage left.
	public float AddDamage(float damage) {
		if (!invulnerable) {
			health -= damage;
			if (health <= 0) {
				AudioSource.PlayClipAtPoint (deathSound, transform.position);
				Die ();
				return health * -1; // return any damage exceeding the health.
			} else {
				return 0;
			}
		} else {
			return 0f;
		}
	}
		
	void OnTriggerEnter2D(Collider2D col) {
		Laser laser = col.gameObject.GetComponent<EnemyLaser> ();
		if (laser) {
			laser.Damage = AddDamage (laser.Damage);
			laser.Hit ();
		}
	}

	void Die() {
		LevelManager mgr = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		mgr.LoadLevel ("Win Screen");
		Destroy (gameObject);
	}
}
