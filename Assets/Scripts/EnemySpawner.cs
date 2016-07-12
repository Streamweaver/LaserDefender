using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public float speed = 4.0f;
	public float width = 10f;
	public float height = 3f;
	public float xMin;
	public float xMax;

	private bool moveRight = false;

	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn() {
		float camDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,camDistance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,camDistance));
		xMin = leftmost.x;
		xMax = rightmost.x;

		if(NextFreePosition ()) {
			Invoke ("SpawnUntilFull", Random.Range (0.3f, 0.6f));
		}

	}

	void SpawnUntilFull() {
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if (moveRight) {
			transform.position += Vector3.right * Time.deltaTime * speed;
		} else {
			transform.position += Vector3.left * Time.deltaTime * speed;
		}

		float limitRight = transform.position.x + 0.5f * width;
		float limitLeft = transform.position.x - 0.5f * width;
		if (limitLeft <= xMin) {
			moveRight = true;
		} else if (limitRight >= xMax) {
			moveRight = false;
		}

		if (AllMembersDead()) {
			Spawn ();
		}
	}

	Transform NextFreePosition() {
		foreach(Transform position in transform) {
			if (position.childCount < 1) {
				return position;
			}
		}
		return null;
	}

	bool AllMembersDead() {
		foreach (Transform position in transform) {
			if(position.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
