using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	private Text _scoreField;

	public static int score;

	// Use this for initialization
	void Start () {
		_scoreField = GameObject.Find("ScoreValue").GetComponent<Text> ();
		Reset ();
	}

	public void Score(int points) {
		score += points;
		_scoreField.text = score.ToString();
	}

	public static void Reset() {
		score = 0;
	}
		
}
