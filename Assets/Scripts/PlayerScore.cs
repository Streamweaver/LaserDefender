using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text scoreText = GetComponent<Text> ();
		scoreText.text = GUIManager.score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
