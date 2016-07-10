using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	public float padding = 1;
	public GameObject laserPrefab;

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
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position +=  Vector3.right * Time.deltaTime * speed;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position +=  Vector3.left * Time.deltaTime * speed;
		}
		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
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
		Instantiate (laserPrefab, transform.position, Quaternion.identity);
	}

}
