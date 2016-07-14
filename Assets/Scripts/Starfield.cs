using UnityEngine;
using System.Collections;



[RequireComponent(typeof(ParticleSystem))]
public class Starfield : MonoBehaviour {
	private ParticleSystem _ps;
	private ParticleSystem.Particle[] particlesArray;
	private Color[] starColors;


	// Use this for initialization
	void Start () {
		_ps = GetComponent<ParticleSystem> ();
		// colors from http://www.vendian.org/mncharity/dir3/starcolor/
		starColors = new Color[]{
			new Color(155f, 176f, 255f, 1f),  // O
			new Color(255f, 204f, 111f, 1f)  // M
		};
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {
		
	}
}
