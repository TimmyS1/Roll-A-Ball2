using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackandForth : MonoBehaviour {

	private float startpos;
	private int direction = 1;

	// Use this for initialization
	void Start () {
		startpos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x,
			transform.position.y + Random.Range (0.001f, 0.1f) * direction,
			transform.position.z);
		if (transform.position.y > 3) {
			direction = -1;
		}
		if (transform.position.y < startpos) {
			direction = 1;
		}
	}
}
