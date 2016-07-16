using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {
	private Text _scoreField;

	private int _score;

	// Use this for initialization
	void Start () {
		_scoreField = GameObject.Find("ScoreValue").GetComponent<Text> ();
		Reset ();
	}

	public void Score(int points) {
		_score += points;
		_scoreField.text = _score.ToString();
	}

	public void Reset() {
		_score = 0;
		_scoreField.text = _score.ToString();
	}

}
